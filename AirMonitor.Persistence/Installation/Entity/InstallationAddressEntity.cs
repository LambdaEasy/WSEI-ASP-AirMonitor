using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirMonitor.Domain.Installation;

namespace AirMonitor.Persistence.Installation.Entity
{
    [Table("InstallationAddress")]
    public class InstallationAddressEntity : IEquatable<InstallationAddressEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Country { get; set; }

        [Required]
        [MaxLength(256)]
        public string City { get; set; }

        [Required]
        [MaxLength(512)]
        public string Street { get; set; }

        [MaxLength(256)]
        public string Number { get; set; }

        [Required]
        [MaxLength(1024)]
        public string DisplayAddress1 { get; set; }

        [Required]
        [MaxLength(1024)]
        public string DisplayAddress2 { get; set; }

        #endregion

        #region Constructors

        public InstallationAddressEntity()
        {
            // serializer
        }

        public InstallationAddressEntity(long? id,
                                         string country,
                                         string city,
                                         string street,
                                         string number,
                                         string displayAddress1,
                                         string displayAddress2)
        {
            Id = id;
            Country = country;
            City = city;
            Street = street;
            Number = number;
            DisplayAddress1 = displayAddress1;
            DisplayAddress2 = displayAddress2;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationAddressEntity other)
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
                && Country == other.Country
                && City == other.City
                && Street == other.Street
                && Number == other.Number
                && DisplayAddress1 == other.DisplayAddress1
                && DisplayAddress2 == other.DisplayAddress2;
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
            return Equals((InstallationAddressEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, Country, City, Street, Number, DisplayAddress1, DisplayAddress2);

        #endregion

        #region ObjectOverrides

        public override string ToString()
            => "InstallationAddressEntity(" +
                   $"id={Id}, " +
                   $"country={Country}, " +
                   $"city={City}, " +
                   $"street={Street}, " +
                   $"number={Number}, " +
                   $"displayAddress1={DisplayAddress1}, " +
                   $"displayAddress2={DisplayAddress2}" +
                ")";

        #endregion

        public InstallationAddress ToDomain()
            => new InstallationAddress(Id, Country, City, Street, Number, DisplayAddress1, DisplayAddress2);

        #region StaticConstructors

        public static InstallationAddressEntity FromDomain(InstallationAddress domain)
            => new InstallationAddressEntity(domain.Id,
                                             domain.City,
                                             domain.City,
                                             domain.Street,
                                             domain.Number,
                                             domain.DisplayAddress1,
                                             domain.DisplayAddress2);

        #endregion
    }
}