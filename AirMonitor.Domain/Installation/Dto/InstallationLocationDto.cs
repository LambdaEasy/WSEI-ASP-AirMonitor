using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public readonly struct InstallationLocationDto : IEquatable<InstallationLocationDto>
    {

        #region Fields

        public float Latitude => _latitude;
        public float Longitude => _longitude;
        public float Elevation => _elevation;

        private readonly float _latitude;
        private readonly float _longitude;
        private readonly float _elevation;

        #endregion
        
        #region Constructors
        
        private InstallationLocationDto(float latitude, float longitude, float elevation)
        {
            _latitude = latitude;
            _longitude = longitude;
            _elevation = elevation;
        }
        
        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationLocationDto other)
            => _latitude.Equals(other._latitude)
            && _longitude.Equals(other._longitude)
            && _elevation.Equals(other._elevation);

        public override bool Equals(object obj)
            => obj is InstallationLocationDto other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(_latitude, _longitude, _elevation);

        #endregion

        #region StaticConstructors

        public static InstallationLocationDto FromDomain(InstallationLocation domain)
            => new InstallationLocationDto(domain.Latitude, domain.Longitude, domain.Elevation);
        
        #endregion
    }
}
