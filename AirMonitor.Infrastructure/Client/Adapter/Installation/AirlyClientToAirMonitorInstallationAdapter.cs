using System.Collections.Generic;
using System.Linq;
using AirMonitor.Client.Api;
using AirMonitor.Client.Api.Response.Installation;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;

namespace AirMonitor.Infrastructure.Client.Adapter.Installation
{
    public static class AirlyClientToAirMonitorInstallationAdapter
    {
        public static IEnumerable<InstallationCreateCommand> FromResponse(IEnumerable<GetInstallationsNearestResponse> response)
            => response.Select(FromResponse)
                       .ToHashSet();

        public static InstallationCreateCommand FromResponse(GetInstallationsNearestResponse response)
            => InstallationCreateCommand.Create(
                    response.Id,
                    response.Airly,
                    LocationAdapter.FromResponse(response),
                    AddressAdapter.FromResponse(response.Address),
                    SponsorAdapter.FromResponse(response.Sponsor));

        public static InstallationError ErrorFromResponse(AirlyClientError errorResponse)
            => InstallationError.ClientError(errorResponse.Message);

        private static class LocationAdapter
        {
            internal static InstallationCreateCommand.InstallationCreateCommandLocation FromResponse(
                    GetInstallationsNearestResponse response)
                => InstallationCreateCommand.InstallationCreateCommandLocation.Create(
                        response.Location.Latitude,
                        response.Location.Longitude,
                        response.Elevation);
        }
        
        private static class AddressAdapter
        {
            internal static InstallationCreateCommand.InstallationCreateCommandAddress FromResponse(
                    GetInstallationsNearestResponse.GetInstallationsNearestResponseAddress response)
                => InstallationCreateCommand.InstallationCreateCommandAddress.Create(
                        response.Country,
                        response.City,
                        response.Street,
                        response.Number,
                        response.DisplayAddress1,
                        response.DisplayAddress2);
        }

        private static class SponsorAdapter
        {
            internal static InstallationCreateCommand.InstallationCreateCommandSponsor FromResponse(
                    GetInstallationsNearestResponse.GetInstallationsNearestResponseSponsor response)
                => InstallationCreateCommand.InstallationCreateCommandSponsor.Create(
                        response.Id,
                        response.Name,
                        response.Description,
                        response.Logo,
                        response.Link);
        }
    }
}
