using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Infrastructure.Service
{
    public class InstallationService : IInstallationFacade
    {
        private readonly ILogger<InstallationService> _logger;

        private readonly IInstallationRepository _repository;

        public InstallationService(ILogger<InstallationService> logger, IInstallationRepository repository)
        {
            this._logger = logger ?? throw new ArgumentException("Logger is null.");
            this._repository = repository ?? throw new ArgumentException("IInstallationRepository is null.");
        }

        public Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
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
                _logger,
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
                _logger,
                InstallationOperationType.GetInstallationByExternalId,
                id,
                () => _repository.FindByExternalId(id)
                                 .Map(InstallationDto.FromDomain)
                                 .ToEither(InstallationError.NotFoundByExternalId(id))
            );
        }

        public ISet<InstallationDto> GetAll()
        {
            return TracedOperation.CallSync
            (
                _logger,
                InstallationOperationType.GetAllInstallations,
                "none",
                () => _repository.FindAll()
                                 .Select(InstallationDto.FromDomain)
                                 .ToHashSet()
            );
        }

        public ISet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
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
                _logger,
                InstallationOperationType.DeleteInstallation,
                command,
                () => _repository.DeleteById(command.Id)
            );
        }

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
