using System;

namespace AirMonitor.Domain.Installation
{
    public class InstallationLocation : IEquatable<InstallationLocation>
    {

        #region Fields
        
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }
        
        #endregion
        
        #region Constructors
        
        public InstallationLocation(float latitude, float longitude, float elevation)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
        }
        
        #endregion
        
        #region Equals&HashCode

        public bool Equals(InstallationLocation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Latitude.Equals(other.Latitude)
                && Longitude.Equals(other.Longitude)
                && Elevation.Equals(other.Elevation);
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
            return Equals((InstallationLocation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude, Elevation);
        }
        
        #endregion

        #region StaticConstructors

        public static InstallationLocation Create(float latitude, float longitude, float elevation)
            => new InstallationLocation(latitude, longitude, elevation);
        
        #endregion
    }
}
