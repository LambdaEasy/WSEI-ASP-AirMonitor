using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AirMonitor.Domain.Measurement;

namespace AirMonitor.Persistence.Measurement.Entity
{
    [Table("MeasurementStandards")]
    public class MeasurementStandardEntity : IEquatable<MeasurementStandardEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        
        [Required]
        public int Pollutant { get; set; }
        
        [Required]
        public double Limit { get; set; }
        
        [Required]
        public double Percent { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Averaging { get; set; }
        
        [ForeignKey("Measurement")]
        public long MeasurementId { get; set; }
        // ref
        public MeasurementEntity Measurement { get; set; }

        #endregion

        #region Constructors

        public MeasurementStandardEntity()
        {
            // serializer
        }

        public MeasurementStandardEntity(long? id, 
                                         string name, 
                                         int pollutant, 
                                         double limit, 
                                         double percent, 
                                         string averaging)
        {
            this.Id = id;
            this.Name = name;
            this.Pollutant = pollutant;
            this.Limit = limit;
            this.Percent = percent;
            this.Averaging = averaging;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementStandardEntity other)
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
                && Pollutant == other.Pollutant 
                && Limit.Equals(other.Limit) 
                && Percent.Equals(other.Percent) 
                && Averaging == other.Averaging;
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
            return Equals((MeasurementStandardEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Pollutant, Limit, Percent, Averaging);
        }

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"id{Id}, " +
                   $"name{Name}, " +
                   $"pollutant{Pollutant}, " +
                   $"limit{Limit}, " +
                   $"percent{Percent}, " +
                   $"averaging{Averaging}" +
               ")";

        public MeasurementStandard ToDomain()
            => new MeasurementStandard(Id,
                                       Name,
                                       MeasurementValueType.GetForNameCode(Pollutant),
                                       Limit,
                                       Percent,
                                       Averaging);

        #region StaticConstructors

        public static MeasurementStandardEntity FromDomain(MeasurementStandard domain)
            => new MeasurementStandardEntity(domain.Id, 
                                             domain.Name, 
                                             domain.Pollutant.NameCode, 
                                             domain.Limit, 
                                             domain.Percent, 
                                             domain.Averaging);

        public static ISet<MeasurementStandardEntity> FromDomain(IEnumerable<MeasurementStandard> domain)
            => domain.Select(FromDomain).ToHashSet();

        public static ISet<MeasurementStandard> ToDomain(IEnumerable<MeasurementStandardEntity> entities)
            => entities.Select(entity => entity.ToDomain()).ToHashSet();

        #endregion
    }
}
