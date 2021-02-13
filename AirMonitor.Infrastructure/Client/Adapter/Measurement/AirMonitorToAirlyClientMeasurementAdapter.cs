using AirMonitor.Client.Api.Request.Measurement;

namespace AirMonitor.Infrastructure.Client.Adapter.Measurement
{
    public static class AirMonitorToAirlyClientMeasurementAdapter
    {
        // TODO includeWind, indexType
        public static GetMeasurementByInstallationIdRequest FromCommand(long installationExternalId)
            => GetMeasurementByInstallationIdRequest.Create(installationExternalId);
    }
}
