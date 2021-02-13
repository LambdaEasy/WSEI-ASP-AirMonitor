using AirMonitor.Client.Api.Request.Measurement;

namespace AirMonitor.Infrastructure.Measurement.Client.Adapter
{
    public static class AirMonitorToAirlyClientAdapter
    {
        // TODO includeWind, indexType
        public static GetMeasurementByInstallationIdRequest FromCommand(long installationExternalId)
            => GetMeasurementByInstallationIdRequest.Create(installationExternalId);
    }
}
