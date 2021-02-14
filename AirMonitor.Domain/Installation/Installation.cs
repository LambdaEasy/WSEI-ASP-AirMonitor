using System;

namespace AirMonitor.Domain.Installation
{
    public class Installation : IEquatable<Installation>
    {
        #region Fields
        
        public long? Id { get; set; }
        public long ExternalId { get; set; }
        public bool IsAirly { get; set; }
        public InstallationLocation Location { get; set; }
        public InstallationAddress Address { get; set; }
        public InstallationSponsor Sponsor { get; set; }
        
        #endregion

        #region Constructors

        public Installation(long? id,
                            long externalId,
                            bool isAirly,
                            InstallationLocation location,
                            InstallationAddress address,
                            InstallationSponsor sponsor)
        {
            Id = id;
            ExternalId = externalId;
            IsAirly = isAirly;
            Location = location;
            Address = address;
            Sponsor = sponsor;
        }
        
        #endregion

        #region Equals&HashCode
        
        public bool Equals(Installation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Id == other.Id
                && ExternalId == other.ExternalId
                && IsAirly == other.IsAirly
                && Equals(Location, other.Location)
                && Equals(Address, other.Address)
                && Equals(Sponsor, other.Sponsor);
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
            return Equals((Installation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ExternalId, IsAirly, Location, Address, Sponsor);
        }
        
        #endregion

        #region StaticConstructors
        
        public static Installation Create(long externalId,
                                          bool isAirly,
                                          InstallationLocation location,
                                          InstallationAddress address,
                                          InstallationSponsor sponsor)
            => new Installation(null, externalId, isAirly, location, address, sponsor);
        
        #endregion
    }
}
