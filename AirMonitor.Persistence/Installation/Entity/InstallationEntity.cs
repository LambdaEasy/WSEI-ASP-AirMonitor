using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirMonitor.Domain.Installation;
using InstallationDomain = AirMonitor.Domain.Installation.Installation;

namespace AirMonitor.Persistence.Installation.Entity
{
    [Table("Installations")]
    public class InstallationEntity : IEquatable<InstallationEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }

        [Required]
        public long ExternalId { get; set; }

        [Required]
        public bool IsAirly { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Elevation { get; set; }

        [Required]
        public InstallationAddressEntity Address { get; set; }

        [Required]
        public InstallationSponsorEntity Sponsor { get; set; }

        #endregion

        #region Constructors

        public InstallationEntity()
        {
            // serializer
        }

        public InstallationEntity(long? id,
                                  long externalId,
                                  bool isAirly,
                                  double latitude,
                                  double longitude,
                                  double elevation,
                                  InstallationAddressEntity address,
                                  InstallationSponsorEntity sponsor)
        {
            Id = id;
            ExternalId = externalId;
            IsAirly = isAirly;
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
            Address = address;
            Sponsor = sponsor;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationEntity other)
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
                && Latitude.Equals(other.Latitude)
                && Longitude.Equals(other.Longitude)
                && Elevation.Equals(other.Elevation) 
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
            return Equals((InstallationEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, ExternalId, IsAirly, Latitude, Longitude, Elevation, Address, Sponsor);

        #endregion

        #region ObjectOverrides

        public override string ToString()
            => "InstallationEntity(" +
                   $"id={Id}, " +
                   $"externalId={ExternalId}, " +
                   $"isAirly={IsAirly}, " +
                   $"latitude={Latitude}, " +
                   $"longitude={Longitude}, " +
                   $"elevation={Elevation}, " +
                   $"address={Address}, " +
                   $"sponsor={Sponsor}" +
               ")";

        #endregion

        public InstallationDomain ToDomain()
            => new InstallationDomain(Id,
                                      ExternalId,
                                      IsAirly,
                                      InstallationLocation.Create(Latitude, Longitude, Elevation),
                                      Address.ToDomain(),
                                      Sponsor.ToDomain());

        #region StaticConstructors

        public static InstallationEntity FromDomain(InstallationDomain domain)
            => new InstallationEntity(domain.Id,
                                      domain.ExternalId,
                                      domain.IsAirly,
                                      domain.Location.Latitude,
                                      domain.Location.Longitude,
                                      domain.Location.Elevation,
                                      InstallationAddressEntity.FromDomain(domain.Address),
                                      InstallationSponsorEntity.FromDomain(domain.Sponsor));

        #endregion

    }
}
