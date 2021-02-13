using AirMonitor.Client.Api.Request.Measurement;
using AirMonitor.Core.Measurement.Command;

namespace AirMonitor.Infrastructure.Client.Adapter.Measurement
{
    public static class AirMonitorToAirlyClientMeasurementAdapter
    {
        // TODO includeWind, indexType
        public static GetMeasurementByInstallationIdRequest FromCommand(MeasurementGetByInstallationExternalIdCommand command)
            => GetMeasurementByInstallationIdRequest.Create(command.InstallationExternalId);
    }
}
