using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AirMonitor.Domain.Measurement;

namespace AirMonitor.Persistence.Measurement.Entity
{
    [Table("MeasurementValues")]
    public class MeasurementValueEntity : IEquatable<MeasurementValueEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public double Value { get; set; }
        
        [ForeignKey("Measurement")]
        public long MeasurementId { get; set; }
        // ref
        public MeasurementEntity Measurement { get; set; }

        #endregion

        #region Constructors

        public MeasurementValueEntity()
        {
            // serializer
        }

        public MeasurementValueEntity(long? id,
                                      int type,
                                      double value)
        {
            this.Id = id;
            this.Type = type;
            this.Value = value;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementValueEntity other)
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
                && Equals(Type, other.Type)
                && Value.Equals(other.Value);
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
            return Equals((MeasurementValueEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, Type, Value);

        #endregion

        public MeasurementValue ToDomain()
            => new MeasurementValue(Id, MeasurementValueType.GetForNameCode(Type), Value);

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"id={Id}, " +
                   $"type={Type}, " +
                   $"value={Value}" +
               ")";

        #region StaticConstructors

        public static MeasurementValueEntity FromDomain(MeasurementValue domain)
            => new MeasurementValueEntity(domain.Id, domain.Type.NameCode, domain.Value);

        public static ISet<MeasurementValueEntity> FromDomain(IEnumerable<MeasurementValue> domain)
            => domain.Select(FromDomain).ToHashSet();

        public static ISet<MeasurementValue> ToDomain(IEnumerable<MeasurementValueEntity> entities)
            => entities.Select(entity => entity.ToDomain()).ToHashSet();

        #endregion
    }
}
