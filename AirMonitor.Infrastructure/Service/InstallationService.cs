using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Infrastructure.Flow;
using AirMonitor.Util.Flow;

namespace AirMonitor.Infrastructure.Service
{
    public class InstallationService : IInstallationFacade
    {
        private const string LoggerName = "InstallationService";
        private readonly IInstallationRepository _repository;

        private InstallationService(IInstallationRepository repository)
        {
            this._repository = repository;
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.CreateInstallation,
                command,
                () => _repository.TrySave(command.ToDomain())
                                 .Map(InstallationDto.FromDomain)
                                 .ToEither(InstallationError.DuplicateExternalId(command.ExternalId))
            );
        }

        public Either<InstallationError, InstallationDto> GetById(long id)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.GetInstallationById,
                id,
                () => _repository.FindById(id)
                                 .Map(InstallationDto.FromDomain)
                                 .ToEither(InstallationError.NotFoundById(id))
            );
        }

        public Either<InstallationError, InstallationDto> GetByExternalId(long id)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.GetInstallationByExternalId,
                id,
                () => _repository.FindByExternalId(id)
                                 .Map(InstallationDto.FromDomain)
                                 .ToEither(InstallationError.NotFoundByExternalId(id))
            );
        }

        public HashSet<InstallationDto> GetAll()
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.GetAllInstallations,
                "none",
                () => _repository.FindAll()
                                 .Select(InstallationDto.FromDomain)
                                 .ToHashSet()
            );
        }

        public HashSet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.GetAllInstallationsNearby,
                command,
                () => _repository.FindAllByLocation(command.Latitude, command.Longitude, command.Radius)
                                 .Select(InstallationDto.FromDomain)
                                 .ToHashSet()
            );
        }

        public Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command)
        {
            // TODO [log]
            throw new System.NotImplementedException();
        }

        public bool Delete(InstallationDeleteCommand command)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                InstallationOperationType.DeleteInstallation,
                command,
                () => _repository.DeleteById(command.Id)
            );
        }

        #region StaticConstructors

        public static class Factory
        {
            public static IInstallationFacade Create(IInstallationRepository repository)
                => new InstallationService(repository ?? throw new ArgumentException("IInstallationRepository is null."));
        }

        #endregion


        #region OperationTypeEnum

        public enum InstallationOperationType
        {
            CreateInstallation,
            GetInstallationById,
            GetInstallationByExternalId,
            GetAllInstallations,
            GetAllInstallationsNearby,
            UpdateInstallation,
            DeleteInstallation
        }

        #endregion
    }
}
