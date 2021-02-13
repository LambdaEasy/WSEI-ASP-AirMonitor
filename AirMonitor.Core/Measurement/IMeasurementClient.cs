using System.Collections.Generic;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Util.Flow;
using MeasurementDomain = AirMonitor.Domain.Measurement.Measurement;

namespace AirMonitor.Core.Measurement
{
    public interface IMeasurementClient
    {
        /// <summary>
        /// Queries external api for up to date measurements for given installation id (external api id).
        /// </summary>
        /// <param name="command">Command consisting of all required data to perform api search.</param>
        /// <returns>Either a list of measurements or an error that occured.</returns>
        Either<MeasurementError, IEnumerable<MeasurementDomain>> GetInstallationsNearby(MeasurementGetByInstallationExternalIdCommand command);
    }
}
