using System;

namespace AirMonitor.Domain.Installation
{
    public class InstallationSponsor : IEquatable<InstallationSponsor>
    {
        #region Fields

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string LinkUri { get; set; }

        #endregion

        #region Constructors

        public InstallationSponsor(long id,
                                   string name,
                                   string description,
                                   string logoUri,
                                   string linkUri)
        {
            Id = id;
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
            return Id == other.Id
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
            return HashCode.Combine(Id, Name, Description, LogoUri, LinkUri);
        }
            
        #endregion

        #region StaticConstructors
        
        public static InstallationSponsor Create(long id,
                                                 string name,
                                                 string description,
                                                 string logoUri,
                                                 string linkUri)
            => new InstallationSponsor(id, name, description, logoUri, linkUri);
            
        #endregion
    }
}
