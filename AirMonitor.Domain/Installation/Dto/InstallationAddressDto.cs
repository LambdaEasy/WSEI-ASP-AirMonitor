using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public class InstallationAddressDto : IEquatable<InstallationAddressDto>
    {
        #region Fields

        public long Id => _id;
        public string Country => _country;
        public string City => _city;
        public string Street => _street;
        public string Number => _number;
        public string DisplayAddress1 => _displayAddress1;
        public string DisplayAddress2 => _displayAddress2;

        private readonly long _id;
        private readonly string _country;
        private readonly string _city;
        private readonly string _street;
        private readonly string _number;
        private readonly string _displayAddress1;
        private readonly string _displayAddress2;

        #endregion

        #region Constructors

        private InstallationAddressDto(long id,
                                       string country,
                                       string city,
                                       string street,
                                       string number,
                                       string displayAddress1,
                                       string displayAddress2)
        {
            _id = id;
            _country = country;
            _city = city;
            _street = street;
            _number = number;
            _displayAddress1 = displayAddress1;
            _displayAddress2 = displayAddress2;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationAddressDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _id == other._id
                && _country == other._country
                && _city == other._city
                && _street == other._street
                && _number == other._number
                && _displayAddress1 == other._displayAddress1
                && _displayAddress2 == other._displayAddress2;
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
            return Equals((InstallationAddressDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_id, _country, _city, _street, _number, _displayAddress1, _displayAddress2);

        #endregion

        #region StaticConstructors

        public static InstallationAddressDto FromDomain(InstallationAddress domain)
            => new InstallationAddressDto(domain.Id ?? throw new ArgumentException("Id is null"),
                                          domain.Country,
                                          domain.City,
                                          domain.Street,
                                          domain.Number,
                                          domain.DisplayAddress1,
                                          domain.DisplayAddress2);

        #endregion
    }
}
