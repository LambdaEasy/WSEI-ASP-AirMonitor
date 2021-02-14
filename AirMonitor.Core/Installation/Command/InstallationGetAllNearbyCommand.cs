namespace AirMonitor.Core.Installation.Command
{
    public readonly struct InstallationGetAllNearbyCommand
    {
        #region Fields

        public double Latitude => _latitude;
        public double Longitude => _longitude;
        public int Radius => _radius;

        private readonly double _latitude;
        private readonly double _longitude;
        private readonly int _radius;

        #endregion

        #region Constructors

        private InstallationGetAllNearbyCommand(double latitude, double longitude, int radius)
        {
            _latitude = latitude;
            _longitude = longitude;
            _radius = radius;
        }

        #endregion

        public override string ToString()
            => $"InstallationGetAllNearbyCommand(latitude={_latitude}, longitude={_longitude}, radius={_radius})";

        #region StaticConstructors

        public static InstallationGetAllNearbyCommand Create(double latitude, double longitude, int radius = 3)
            // TODO validate
            => new InstallationGetAllNearbyCommand(latitude, longitude, radius);

        #endregion
    }
}
