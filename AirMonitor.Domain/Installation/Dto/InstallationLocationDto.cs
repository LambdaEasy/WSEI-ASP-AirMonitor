using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public class InstallationLocationDto : IEquatable<InstallationLocationDto>
    {

        #region Fields

        public double Latitude => _latitude;
        public double Longitude => _longitude;
        public double Elevation => _elevation;

        private readonly double _latitude;
        private readonly double _longitude;
        private readonly double _elevation;

        #endregion
        
        #region Constructors
        
        private InstallationLocationDto(double latitude, double longitude, double elevation)
        {
            _latitude = latitude;
            _longitude = longitude;
            _elevation = elevation;
        }
        
        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationLocationDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _latitude.Equals(other._latitude)
                && _longitude.Equals(other._longitude)
                && _elevation.Equals(other._elevation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((InstallationLocationDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_latitude, _longitude, _elevation);

        #endregion

        #region StaticConstructors

        public static InstallationLocationDto FromDomain(InstallationLocation domain)
            => new InstallationLocationDto(domain.Latitude, domain.Longitude, domain.Elevation);
        
        #endregion
    }
}
