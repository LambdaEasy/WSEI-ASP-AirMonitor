using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirMonitor.Persistence.Installation.Entity;
using MeasurementDomain = AirMonitor.Domain.Measurement.Measurement;

namespace AirMonitor.Persistence.Measurement.Entity
{
    [Table("Measurement")]
    public class MeasurementEntity : IEquatable<MeasurementEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }
        
        [Required]
        public long InstallationExternalId { get; set; }
        
        [Required]
        public DateTimeOffset UpdateDateTime { get; set; }
        
        [Required]
        public DateTimeOffset FromDateTime { get; set; }
        
        [Required]
        public DateTimeOffset TillDateTime { get; set; }

        public ISet<MeasurementValueEntity> Values { get; set; }
        public ISet<MeasurementIndexEntity> Indexes { get; set; }
        public ISet<MeasurementStandardEntity> Standards { get; set; }

        #endregion

        #region Constructors

        public MeasurementEntity()
        {
            // serializer
        }

        public MeasurementEntity(long? id,
                                 long installationExternalId,
                                 DateTimeOffset updateDateTime,
                                 DateTimeOffset fromDateTime,
                                 DateTimeOffset tillDateTime,
                                 ISet<MeasurementValueEntity> values,
                                 ISet<MeasurementIndexEntity> indexes,
                                 ISet<MeasurementStandardEntity> standards)
        {
            this.Id = id;
            this.InstallationExternalId = installationExternalId;
            this.UpdateDateTime = updateDateTime;
            this.FromDateTime = fromDateTime;
            this.TillDateTime = tillDateTime;
            this.Values = values;
            this.Indexes = indexes;
            this.Standards = standards;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementEntity other)
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
                && InstallationExternalId == other.InstallationExternalId
                && UpdateDateTime.Equals(other.UpdateDateTime)
                && FromDateTime.Equals(other.FromDateTime)
                && TillDateTime.Equals(other.TillDateTime)
                && Equals(Values, other.Values)
                && Equals(Indexes, other.Indexes)
                && Equals(Standards, other.Standards);
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
            return Equals((MeasurementEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, InstallationExternalId, UpdateDateTime, FromDateTime, TillDateTime, Values, Indexes, Standards);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" + 
                   $"id={Id}, " +
                   $"installationExternalId={InstallationExternalId}, " +
                   $"updateDateTime={UpdateDateTime}, " +
                   $"fromDateTime={FromDateTime}, " +
                   $"tillDateTime={TillDateTime}, " +
                   $"values={Values}, " +
                   $"indexes={Indexes}, " +
                   $"standards={Standards}" +
               ")";

        public MeasurementDomain ToDomain()
            => new MeasurementDomain(Id,
                                     InstallationExternalId,
                                     UpdateDateTime,
                                     FromDateTime,
                                     TillDateTime,
                                     MeasurementValueEntity.ToDomain(Values),
                                     MeasurementIndexEntity.ToDomain(Indexes),
                                     MeasurementStandardEntity.ToDomain(Standards));

        #region StaticConstructors

        public static MeasurementEntity FromDomain(MeasurementDomain domain)
            => new MeasurementEntity(domain.Id,
                                     domain.InstallationExternalId,
                                     domain.UpdateDateTime,
                                     domain.FromDateTime,
                                     domain.TillDateTime,
                                     MeasurementValueEntity.FromDomain(domain.Values),
                                     MeasurementIndexEntity.FromDomain(domain.Indexes),
                                     MeasurementStandardEntity.FromDomain(domain.Standards));

        #endregion
    }
}
