using System.Collections.Generic;
using AirMonitor.Domain.Installation.Dto;

namespace AirMonitor.Web.Models.Installation
{
    public class InstallationNearbyViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ISet<InstallationDto> Installations { get; set; }

        public InstallationNearbyViewModel(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Installations = new HashSet<InstallationDto>();
        }
        
        public InstallationNearbyViewModel(double latitude, double longitude, ISet<InstallationDto> installations)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Installations = installations;
        }

        public static InstallationNearbyViewModel Success(double latitude,
                                                          double longitude,
                                                          ISet<InstallationDto> installations)
            => new InstallationNearbyViewModel(latitude, longitude, installations);
    }
}
