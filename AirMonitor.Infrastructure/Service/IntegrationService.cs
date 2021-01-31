using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Infrastructure.Service
{
    public class IntegrationService : IInstallationFacade
    {
        private readonly IInstallationFacade _core;
        private readonly IInstallationClient _integration;

        private IntegrationService(IInstallationFacade core, IInstallationClient integration)
        {
            this._core = core;
            this._integration = integration;
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
            => _core.CreateInstallation(command);

        public Either<InstallationError, InstallationDto> GetById(long id)
            => RunIntegration(_core.GetById(id));

        public Either<InstallationError, InstallationDto> GetByExternalId(long id)
            => RunIntegration(_core.GetByExternalId(id));

        // TODO return either
        public HashSet<InstallationDto> GetAll()
            => _core.GetAll()
                    .Select(Either<InstallationError, InstallationDto>.Right<InstallationError, InstallationDto>)
                    .Select(RunIntegration)
                    .Where(it => it.IsRight)
                    .Select(it => it.Get)
                    .ToHashSet();

        // TODO return either
        public HashSet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
            => _integration.GetInstallationsNearby(command)
                           .Map(installations =>
                           {
                               return installations.Select(CreateInstallation)
                                                   .Where(it => it.IsRight)
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
            // TODO Either.FlatMap?
            if (context.IsLeft)
            {
                return context;
            }

            if (context.IsRight && context.Get.IsReadValid)
            {
                return context;
            }
            return Update(InstallationUpdateCommand.TemporaryDevCreate(context.Get));
        }
    }
}
