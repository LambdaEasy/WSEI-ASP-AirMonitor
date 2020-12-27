using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public class InstallationSponsorDto : IEquatable<InstallationSponsorDto>
    {
        #region Fields

        public long InstallationId => _installationId;
        public string Name => _name;
        public string Description => _description;
        public string LogoUri => _logoUri;
        public string LinkUri => _linkUri;

        private readonly long _installationId;
        private readonly string _name;
        private readonly string _description;
        private readonly string _logoUri;
        private readonly string _linkUri;

        #endregion

        #region Constructors

        public InstallationSponsorDto(long installationId,
                                      string name,
                                      string description,
                                      string logoUri,
                                      string linkUri)
        {
            _installationId = installationId;
            _name = name;
            _description = description;
            _logoUri = logoUri;
            _linkUri = linkUri;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationSponsorDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _installationId == other._installationId
                && _name == other._name
                && _description == other._description
                && _logoUri == other._logoUri
                && _linkUri == other._linkUri;
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
            return Equals((InstallationSponsorDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_installationId, _name, _description, _logoUri, _linkUri);
        }

        #endregion

        #region StaticConstructors
        
        public static InstallationSponsorDto FromDomain(InstallationSponsor domain)
            => new InstallationSponsorDto(domain.InstallationId ?? throw new ArgumentException("LocationId is null"), 
                                          domain.Name,
                                          domain.Description,
                                          domain.LogoUri,
                                          domain.LinkUri);
            
        #endregion
    }
}
