using System;
using System.Collections.Generic;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Core.Util.Flow;
using AirMonitor.Domain.Installation.Dto;

namespace AirMonitor.Infrastructure.Service
{
    public class InstallationService : IInstallationFacade
    {
        private readonly IInstallationRepository _repository;

        private InstallationService(IInstallationRepository repository)
        {
            this._repository = repository;
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Either<InstallationError, InstallationDto> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Either<InstallationError, InstallationDto> GetByExternalId(long id)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<InstallationDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public HashSet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(InstallationDeleteCommand command)
        {
            throw new System.NotImplementedException();
        }

        public static class Factory
        {
            public static IInstallationFacade Create(IInstallationRepository repository)
                => new InstallationService(repository ?? throw new ArgumentException("IInstallationRepository is null."));
        }
    }
}
