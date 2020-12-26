using System;

namespace AirMonitor.Domain.Installation
{
    public class InstallationSponsor : IEquatable<InstallationSponsor>
    {
        #region Fields

        public long? InstallationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string LinkUri { get; set; }

        #endregion

        #region Constructors

        public InstallationSponsor(long? installationId,
                                   string name,
                                   string description,
                                   string logoUri,
                                   string linkUri)
        {
            InstallationId = installationId;
            Name = name;
            Description = description;
            LogoUri = logoUri;
            LinkUri = linkUri;
        }

        #endregion

        #region Equals&HashCode
        
        public bool Equals(InstallationSponsor other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return InstallationId == other.InstallationId
                && Name == other.Name
                && Description == other.Description
                && LogoUri == other.LogoUri
                && LinkUri == other.LinkUri;
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
            return Equals((InstallationSponsor) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstallationId, Name, Description, LogoUri, LinkUri);
        }
            
        #endregion

        #region StaticConstructors
        
        public static InstallationSponsor Create(string name,
                                                 string description,
                                                 string logoUri,
                                                 string linkUri)
            => new InstallationSponsor(null, name, description, logoUri, linkUri);
            
        #endregion
    }
}
