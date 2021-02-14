using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Core.Measurement;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Domain.Measurement.Dto;
using AirMonitor.Util.Flow;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Infrastructure.Service
{
    public class AirlyIntegrationService : IIntegrationFacade
    {
        private readonly ILogger<AirlyIntegrationService> _logger;

        private readonly IInstallationFacade _installationCore;
        private readonly IInstallationClient _installationIntegration;

        private readonly IMeasurementFacade _measurementCore;
        private readonly IMeasurementClient _measurementIntegration;

        public AirlyIntegrationService(ILogger<AirlyIntegrationService> logger,
                                       IInstallationFacade installationCore,
                                       IInstallationClient installationIntegration,
                                       IMeasurementFacade measurementCore,
                                       IMeasurementClient measurementIntegration)
        {
            _logger = logger ?? throw new ArgumentException("Logger is null");
            _installationCore = installationCore ?? throw new ArgumentException("IInstallationFacade is null");
            _installationIntegration = installationIntegration ?? throw new ArgumentException("IInstallationClient is null");
            _measurementCore = measurementCore ?? throw new ArgumentException("IMeasurementFacade is null");
            _measurementIntegration = measurementIntegration ?? throw new ArgumentException("IMeasurementClient is null");
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
            => _RunIntegration(_installationCore.CreateInstallation(command));

        public Either<InstallationError, InstallationDto> GetById(long id)
            => _RunIntegration(_installationCore.GetById(id));

        public Either<InstallationError, InstallationDto> GetByExternalId(long externalId)
            => _RunIntegration(_installationCore.GetByExternalId(externalId));

        public ISet<InstallationDto> GetAll()
            => _installationCore.GetAll()
                                .Select(_RunIntegration)
                                .Select(integrationResult =>
                                {
                                    if (integrationResult.IsLeft)
                                    {
                                        _logger.LogWarning($"Integration result was a failure and will be skipped in result set = {integrationResult.GetLeft}");
                                    }
                                    return integrationResult;
                                })
                                .Where(integrationResult => integrationResult.IsRight)
                                .Select(integrationResult => integrationResult.Get)
                                .ToHashSet();

        public ISet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
            => _installationIntegration.GetInstallationsNearby(command)
                                       .PeekLeft(integrationFailure =>
                                       {
                                           _logger.LogWarning($"Integration failure = {integrationFailure}");
                                       })
                                       .Map(CreateOrUpdateBatch)
                                       .GetOrElse(new HashSet<InstallationDto>());
        
        // TODO batches and updates
        private ISet<InstallationDto> CreateOrUpdateBatch(IEnumerable<InstallationCreateCommand> commands)
            => commands.Select(command =>
                       {
                           // TODO flat map on Either
                           var saveResult = this.CreateInstallation(command);
                           if (saveResult.IsLeft)
                           {
                               return this.GetByExternalId(command.ExternalId); // TODO update instead
                           }
                           return saveResult;
                       })
                       .Select(coreResult =>
                       {
                           if (coreResult.IsLeft)
                           {
                               _logger.LogWarning($"Core result was a failure and will be skipped in result set = {coreResult.GetLeft}");
                           }
                           return coreResult;
                       })
                       .Where(coreResult => coreResult.IsRight)
                       .Select(coreResult => coreResult.Get)
                       .ToHashSet();


        public Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command)
        {
            throw new NotImplementedException();
        }
        
        public bool Delete(InstallationDeleteCommand command)
        {
            throw new NotImplementedException();
        }

        private Either<InstallationError, InstallationDto> _RunIntegration(Either<InstallationError, InstallationDto> coreResult)
            // TODO flatMap on Either
            => coreResult.IsLeft ? coreResult : _RunIntegration(coreResult.Get);

        private Either<InstallationError, InstallationDto> _RunIntegration(InstallationDto installation)
        {
            var measurementIntegration = RunMeasurementIntegration(installation.ExternalId);
            if (measurementIntegration.IsLeft)
            {
                return Either<InstallationError, InstallationDto>.Left<InstallationError, InstallationDto>(
                    InstallationError.MeasurementUpdateFailed(measurementIntegration.GetLeft));
            }
            // TODO add measurements to installation
            return Either<InstallationError, InstallationDto>.Right<InstallationError, InstallationDto>(
                installation.WithMeasurement(measurementIntegration.Get));
        }

        private Either<MeasurementError, MeasurementDto> RunMeasurementIntegration(long installationExternalId)
        {
            bool isOutdated = _measurementCore.IsOutdatedByInstallationExternalId(installationExternalId);
            if (!isOutdated)
            {
                return _measurementCore.GetByExternalId(installationExternalId);
            }
            var command = MeasurementGetByInstallationExternalIdCommand.Create(installationExternalId);
            var integrationResult = _measurementIntegration.GetMeasurementByInstallationId(command);
            // TODO flatMap on Either
            if (integrationResult.IsLeft)
            {
                return Either<MeasurementError, MeasurementDto>.Left<MeasurementError, MeasurementDto>(integrationResult.GetLeft);
            }
            return _measurementCore.Update(integrationResult.Get);
        }
    }
}
