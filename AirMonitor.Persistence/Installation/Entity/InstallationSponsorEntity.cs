using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirMonitor.Domain.Installation;

namespace AirMonitor.Persistence.Installation.Entity
{
    [Table("InstallationSponsor")]
    public class InstallationSponsorEntity : IEquatable<InstallationSponsorEntity>
    {
        #region Fields

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        // nvarchar(max)
        public string Description { get; set; }

        [Required]
        [MaxLength(512)]
        public string LogoUri { get; set; }

        [Required]
        [MaxLength(512)]
        public string LinkUri { get; set; }

        #endregion

        #region Constructors

        public InstallationSponsorEntity()
        {
            // serializer
        }

        public InstallationSponsorEntity(long id, 
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

        public bool Equals(InstallationSponsorEntity other)
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
            return Equals((InstallationSponsorEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, Name, Description, LogoUri, LinkUri);

        #endregion

        #region ObjectOverrides

        public override string ToString()
            => "InstallationSponsorEntity(" +
                   $"id={Id}, " +
                   $"name={Name}, " +
                   $"description={Description}, " +
                   $"logoUri={LogoUri}, " +
                   $"linkUri={LinkUri}" +
               ")";

        #endregion
        
        public InstallationSponsor ToDomain()
            => new InstallationSponsor(Id, Name, Description, LogoUri, LinkUri);

        #region StaticConstructors

        public static InstallationSponsorEntity FromDomain(InstallationSponsor domain)
            => new InstallationSponsorEntity(domain.Id,
                                             domain.Name,
                                             domain.Description,
                                             domain.LogoUri,
                                             domain.LinkUri);

        #endregion
    }
}