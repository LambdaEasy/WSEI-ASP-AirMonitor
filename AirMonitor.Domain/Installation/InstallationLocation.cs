using System;

namespace AirMonitor.Domain.Installation
{
    public class InstallationLocation : IEquatable<InstallationLocation>
    {

        #region Fields
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        
        #endregion
        
        #region Constructors
        
        public InstallationLocation(double latitude, double longitude, double elevation)
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

        public static InstallationLocation Create(double latitude, double longitude, double elevation)
            => new InstallationLocation(latitude, longitude, elevation);
        
        #endregion
    }
}
