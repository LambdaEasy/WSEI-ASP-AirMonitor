using AirMonitor.Client.Api.Request.Installation;
using AirMonitor.Core.Installation.Command;

namespace AirMonitor.Infrastructure.Service.Client.Adapter
{
    public static class AirMonitorToAirlyClientAdapter
    {
        public static GetInstallationsNearestRequest FromCommand(InstallationGetAllNearbyCommand command)
            => GetInstallationsNearestRequest.Create(command.Latitude, command.Longitude, command.Radius);
    }
}
