namespace AirMonitor.Core.Installation.Command
{
    public readonly struct InstallationGetAllNearbyCommand
    {
        #region Fields

        public float Latitude => _latitude;
        public float Longitude => _longitude;
        public int Radius => _radius;

        private readonly float _latitude;
        private readonly float _longitude;
        private readonly int _radius;

        #endregion

        #region Constructors

        private InstallationGetAllNearbyCommand(float latitude, float longitude, int radius)
        {
            _latitude = latitude;
            _longitude = longitude;
            _radius = radius;
        }

        #endregion

        public override string ToString()
            => $"InstallationGetAllNearbyCommand(latitude={_latitude}, longitude={_longitude}, radius={_radius})";

        #region StaticConstructors

        public static InstallationGetAllNearbyCommand Create(float latitude, float longitude, int radius = 3)
            // TODO validate
            => new InstallationGetAllNearbyCommand(latitude, longitude, radius);

        #endregion
    }
}
