using AirMonitor.Client.Api.Request.Installation;
using AirMonitor.Core.Installation.Command;

namespace AirMonitor.Infrastructure.Client.Adapter.Installation
{
    public static class AirMonitorToAirlyClientInstallationAdapter
    {
        public static GetInstallationsNearestRequest FromCommand(InstallationGetAllNearbyCommand command)
            => GetInstallationsNearestRequest.Create(command.Latitude, command.Longitude, command.Radius);
    }
}
