using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AirMonitor.Core;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Infrastructure.Service
{
    [Obsolete("_Obsolete_IntegrationService was replaced by AirlyIntegrationService")]
    public class _Obsolete_IntegrationService : IIntegrationFacade
    {
        private readonly ILogger<_Obsolete_IntegrationService> _logger;

        private readonly IInstallationFacade _core;
        private readonly IInstallationClient _integration;

        public _Obsolete_IntegrationService(ILogger<_Obsolete_IntegrationService> logger,
                                  IInstallationFacade core,
                                  IInstallationClient integration)
        {
            this._logger = logger ?? throw new ArgumentException("Logger is null");
            this._core = core ?? throw new ArgumentException("Core is null");
            this._integration = integration ?? throw new ArgumentException("Integration is null");
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
            => _core.CreateInstallation(command);

        public Either<InstallationError, InstallationDto> GetById(long id)
            => RunIntegration(_core.GetById(id));

        public Either<InstallationError, InstallationDto> GetByExternalId(long id)
            => RunIntegration(_core.GetByExternalId(id));

        // TODO return either
        public ISet<InstallationDto> GetAll()
            => _core.GetAll()
                    .Select(Either<InstallationError, InstallationDto>.Right<InstallationError, InstallationDto>)
                    .Select(RunIntegration)
                    .Where(it =>
                    {
                        if (it.IsLeft)
                        {
                            // TODO info which failed through error
                            _logger.LogWarning("Integration result was a failure and will be skipped in result set.");
                        }
                        return it.IsRight;
                    })
                    .Select(it => it.Get)
                    .ToHashSet();

        // TODO return either
        public ISet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
            => _integration.GetInstallationsNearby(command)
                           // TODO createBatch
                           .Map(installations =>
                           {
                               return installations.Select(CreateInstallation)
                                                   .Where(it =>
                                                   {
                                                       if (it.IsLeft)
                                                       {
                                                           // TODO info which failed through error
                                                           _logger.LogWarning("Core result was a failure and will be skipped in result set.");
                                                       }
                                                       return it.IsRight;
                                                   })
                                                   .Select(it => it.Get)
                                                   .ToHashSet();
                           })
                           .GetOrElse(new HashSet<InstallationDto>());

        public Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command)
        {
            // TODO [Measurements]
            return command.TemporaryDevResultFunction();
        }

        public bool Delete(InstallationDeleteCommand command)
            => _core.Delete(command);

        private Either<InstallationError, InstallationDto> RunIntegration(Either<InstallationError, InstallationDto> context)
        {
            DateTimeOffset beginTime = DateTimeOffset.Now;
            _logger.LogInformation($"Integration process begin at {beginTime}");
            if (context.IsLeft)
            {
                _logger.LogWarning($"Integration process finished due to a core error after {FormatExecTime(beginTime)}");
                return context;
            }

            if (context.IsRight && context.Get.IsReadValid)
            {
                _logger.LogTrace($"Integration process finished with no action after {FormatExecTime(beginTime)}");
                return context;
            }
            return Update(InstallationUpdateCommand.TemporaryDevCreate(context.Get))
                   .Peek(success =>
                   {
                       _logger.LogInformation($"Integration process finished with success result after {FormatExecTime(beginTime)}");
                   })
                   .PeekLeft(failure =>
                   {
                       _logger.LogWarning($"Integration process finished due to a integration error after {FormatExecTime(beginTime)}");
                   });
        }

        private static string FormatExecTime(DateTimeOffset beginTime)
            => (DateTime.Now - beginTime).TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
    }
}
