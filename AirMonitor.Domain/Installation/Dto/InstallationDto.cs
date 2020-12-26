using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public class InstallationDto : IEquatable<InstallationDto>
    {
        #region Fields

        public long Id => _id;
        public long ExternalId => _externalId;
        public bool IsAirly => _isAirly;
        public InstallationLocationDto Location => _location;
        public InstallationAddressDto Address => _address;
        public InstallationSponsorDto Sponsor => _sponsor;

        private readonly long _id;
        private readonly long _externalId;
        private readonly bool _isAirly;
        private readonly InstallationLocationDto _location;
        private readonly InstallationAddressDto _address;
        private readonly InstallationSponsorDto _sponsor;

        #endregion

        #region Constructors

        public InstallationDto(long id,
                               long externalId,
                               bool isAirly,
                               InstallationLocationDto location,
                               InstallationAddressDto address,
                               InstallationSponsorDto sponsor)
        {
            _id = id;
            _externalId = externalId;
            _isAirly = isAirly;
            _location = location;
            _address = address;
            _sponsor = sponsor;
        }
        
        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationDto other)
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
                && _externalId == other._externalId
                && _isAirly == other._isAirly
                && Equals(_location, other._location)
                && Equals(_address, other._address)
                && Equals(_sponsor, other._sponsor);
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
            return Equals((InstallationDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_id, _externalId, _isAirly, _location, _address, _sponsor);

        #endregion

        #region StaticConstructors
        
        public static InstallationDto FromDomain(Installation domain)
            => new InstallationDto(domain.Id ?? throw new AggregateException("Id is null"),
                                   domain.ExternalId,
                                   domain.IsAirly,
                                   InstallationLocationDto.FromDomain(domain.Location),
                                   InstallationAddressDto.FromDomain(domain.Address),
                                   InstallationSponsorDto.FromDomain(domain.Sponsor));
        
        #endregion
    }
}
