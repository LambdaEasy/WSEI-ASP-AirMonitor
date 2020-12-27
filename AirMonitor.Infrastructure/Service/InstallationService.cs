using System;
using System.Collections.Generic;
using System.Linq;
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
            // TODO [log]
            throw new System.NotImplementedException();
        }

        public Either<InstallationError, InstallationDto> GetById(long id)
        {
            // TODO [log]
            return _repository.FindById(id)
                              .Map(InstallationDto.FromDomain)
                              .ToEither(InstallationError.NotFoundById(id));
        }

        public Either<InstallationError, InstallationDto> GetByExternalId(long id)
        {
            // TODO [log]
            return _repository.FindByExternalId(id)
                              .Map(InstallationDto.FromDomain)
                              .ToEither(InstallationError.NotFoundByExternalId(id));
        }

        public HashSet<InstallationDto> GetAll()
        {
            // TODO [log]
            return _repository.FindAll()
                              .Select(InstallationDto.FromDomain)
                              .ToHashSet();
        }

        public HashSet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
        {
            // TODO [log]
            throw new System.NotImplementedException();
        }

        public Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command)
        {
            // TODO [log]
            throw new System.NotImplementedException();
        }

        public bool Delete(InstallationDeleteCommand command)
        {
            // TODO [log]
            return _repository.DeleteById(command.Id);
        }

        public static class Factory
        {
            public static IInstallationFacade Create(IInstallationRepository repository)
                => new InstallationService(repository ?? throw new ArgumentException("IInstallationRepository is null."));
        }
    }
}
