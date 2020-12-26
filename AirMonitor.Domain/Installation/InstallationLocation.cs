namespace AirMonitor.Domain.Installation
{
    public class InstallationLocation
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }

        public InstallationLocation(float latitude, float longitude, float elevation)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
        }

        public static InstallationLocation Create(float latitude, float longitude, float elevation)
            => new InstallationLocation(latitude, longitude, elevation);
    }
}
