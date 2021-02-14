using System;

namespace AirMonitor.Domain.Installation
{
    public class InstallationAddress : IEquatable<InstallationAddress>
    {

        #region Fields
        
        public long? Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DisplayAddress1 { get; set; }
        public string DisplayAddress2 { get; set; }
        
        #endregion

        #region Constructors
        
        public InstallationAddress(long? id,
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

        public bool Equals(InstallationAddress other)
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
            return Equals((InstallationAddress) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Country, City, Street, Number, DisplayAddress1, DisplayAddress2);
        }

        #endregion

        #region StaticConstructors

        public static InstallationAddress Create(string country,
                                                 string city,
                                                 string street,
                                                 string number,
                                                 string displayAddress1,
                                                 string displayAddress2)
            => new InstallationAddress(null, country, city, street, number, displayAddress1, displayAddress2);
        
        #endregion
    }
}
