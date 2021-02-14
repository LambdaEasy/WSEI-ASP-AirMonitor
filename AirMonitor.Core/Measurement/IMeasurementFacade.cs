using System.Collections.Generic;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Domain.Measurement.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Core.Measurement
{
    public interface IMeasurementFacade
    {
        /// <summary>
        /// Creates measurement. Saves data in database and return application object.
        /// </summary>
        /// <param name="command">Create command with data necessary to create new Measurement.</param>
        /// <returns>Created measurement or error with occured.</returns>
        Either<MeasurementError, MeasurementDto> Create(MeasurementCreateCommand command);
        
        /// <summary>
        /// Searches stored Measurements by technical uid. 
        /// </summary>
        /// <param name="id">Technical id of Measurement</param>
        /// <returns>Found measurement or error with occured</returns>
        Either<MeasurementError, MeasurementDto> GetById(long id);

        /// <summary>
        /// Searches stored Measurements by external uid. 
        /// </summary>
        /// <param name="externalId">
        /// External id of Measurement.
        /// Its values is assigned to external id of Installation to which this measurement belongs.
        /// </param>
        /// <returns>Found measurement or error with occured</returns>
        Either<MeasurementError, MeasurementDto> GetByExternalId(long externalId);

        /// <summary>
        /// Returns all stored measurements.
        /// </summary>
        /// <returns>Set of measurements</returns>
        ISet<MeasurementDto> GetAll();

        /// <summary>
        /// Returns all stored measurements which reads are outdated.
        /// </summary>
        /// <returns>Set of measurements</returns>
        ISet<MeasurementDto> GetAllOutdatedMeasurement();

        /// <summary>
        /// Checks if measurement is outdated.
        /// </summary>
        /// <param name="installationExternalId">Installation external identifier.</param>
        /// <returns>Set of measurements</returns>
        bool IsOutdatedByInstallationExternalId(long installationExternalId);

        /// <summary>
        /// Updates stored Measurement data and returns new updated Measurement.
        /// </summary>
        /// <param name="command">Command containing data necessary for update.</param>
        /// <returns>Updated Measurement or error which occured</returns>
        Either<MeasurementError, MeasurementDto> Update(MeasurementCreateCommand command);
        
        /// <summary>
        /// Deletes Measurement of given technical Id. Returns operation result.
        /// </summary>
        /// <param name="command">Command with data necessary to delete Measurement.</param>
        /// <returns>True if Measurement was deleted.</returns>
        bool Delete(MeasurementDeleteCommand command);
    }
}
