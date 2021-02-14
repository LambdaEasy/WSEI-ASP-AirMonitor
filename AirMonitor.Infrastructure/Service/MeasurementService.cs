using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Measurement;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Domain.Measurement.Dto;
using AirMonitor.Util.Flow;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Infrastructure.Service
{
    public class MeasurementService : IMeasurementFacade
    {
        private readonly ILogger<MeasurementService> _logger;

        private readonly IMeasurementRepository _repository;

        public MeasurementService(ILogger<MeasurementService> logger, IMeasurementRepository repository)
        {
            this._logger = logger ?? throw new ArgumentException("Logger is null.");
            this._repository = repository ?? throw new ArgumentException("IMeasurementRepository is null.");
        }

        // TODO based of installation id!!!
        public Either<MeasurementError, MeasurementDto> Create(MeasurementCreateCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.CreateMeasurement,
                command,
                () => _repository.TrySave(command.ToDomain())
                                 .Map(MeasurementDto.FromDomain)
                                 .ToEither(MeasurementError.DuplicateExternalId(command.ExternalId))
            );
        }

        public Either<MeasurementError, MeasurementDto> GetById(long id)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.GetIMeasurementById,
                id,
                () => _repository.FindById(id)
                                 .Map(MeasurementDto.FromDomain)
                                 .ToEither(MeasurementError.NotFoundById(id))
            );
        }

        public Either<MeasurementError, MeasurementDto> GetByExternalId(long externalId)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.GetIMeasurementById,
                externalId,
                () => _repository.FindByExternalId(externalId)
                                 .Map(MeasurementDto.FromDomain)
                                 .ToEither(MeasurementError.NotFoundByExternalId(externalId))
            );
        }

        public ISet<MeasurementDto> GetAll()
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.GetAllMeasurements,
                "none",
                () => _repository.FindAll()
                                 .Select(MeasurementDto.FromDomain)
                                 .ToHashSet()
            );
        }

        public ISet<MeasurementDto> GetAllOutdatedMeasurement()
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.GetAllOutdatedMeasurements,
                "none",
                () => _repository.FindAllOutdated()
                                 .Select(MeasurementDto.FromDomain)
                                 .ToHashSet()
            );
        }
        
        public bool IsOutdatedByInstallationExternalId(long installationExternalId)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.IsOutdatedByInstallationExternalId,
                installationExternalId,
                () => _repository.IsOutdatedByInstallationExternalId(installationExternalId)
            );
        }

        public Either<MeasurementError, MeasurementDto> Update(MeasurementCreateCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.UpdateMeasurement,
                command,
                // TODO refactor
                () =>
                {
                    if (_repository.ExistsByExternalId(command.ExternalId))
                    {
                        _repository.DeleteByExternalId(command.ExternalId);
                    }
                    return Create(command);
                }
            );
        }

        public bool Delete(MeasurementDeleteCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
                MeasurementOperationType.DeleteMeasurement,
                command,
                () => _repository.DeleteById(command.Id)
            );
        }
    }

    public enum MeasurementOperationType
    {
        CreateMeasurement,
        GetIMeasurementById,
        GetAllMeasurements,
        GetAllOutdatedMeasurements,
        IsOutdatedByInstallationExternalId,
        UpdateMeasurement,
        DeleteMeasurement
    }
}
