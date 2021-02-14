using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AirMonitor.Domain.Measurement;

namespace AirMonitor.Persistence.Measurement.Entity
{
    [Table("MeasurementIndexes")]
    public class MeasurementIndexEntity : IEquatable<MeasurementIndexEntity>
    {
        #region Fields

        [Key]
        public long? Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public int Name { get; set; }
        
        [Required]
        public double Value { get; set; }
        
        [Required]
        public int Level { get; set; }
        
        [Required]
        // nvarchar(max)
        public string Description { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string Advice { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string Color { get; set; }
        
        [ForeignKey("Measurement")]
        public long MeasurementId { get; set; }
        // ref
        public MeasurementEntity Measurement { get; set; }

        #endregion

        #region Constructors

        public MeasurementIndexEntity()
        {
            // serializer
        }

        public MeasurementIndexEntity(long? id,
                                      int name,
                                      double value,
                                      int level,
                                      string description,
                                      string advice,
                                      string color)
        {
            this.Id = id;
            this.Name = name;
            this.Value = value;
            this.Level = level;
            this.Description = description;
            this.Advice = advice;
            this.Color = color;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementIndexEntity other)
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
                && Value.Equals(other.Value)
                && Level == other.Level
                && Description == other.Description
                && Advice == other.Advice
                && Color == other.Color;
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
            return Equals((MeasurementIndexEntity) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, Name, Value, Level, Description, Advice, Color);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"id={Id}, " +
                   $"name={Name}, " +
                   $"value={Value}, " +
                   $"level={Level}, " +
                   $"description={Description}, " +
                   $"advice={Advice}, " +
                   $"color={Color}" +
               ")";

        public MeasurementIndex ToDomain()
            => new MeasurementIndex(Id,
                                    (MeasurementIndexName) Name,
                                    Value,
                                    (MeasurementIndexLevel) Level,
                                    Description,
                                    Advice,
                                    Color);

        #region StaticConstructors

        public static MeasurementIndexEntity FromDomain(MeasurementIndex domain)
            => new MeasurementIndexEntity(domain.Id,
                                          (int) domain.Name,
                                          domain.Value,
                                          (int) domain.Level,
                                          domain.Description,
                                          domain.Advice,
                                          domain.Color);

        public static ISet<MeasurementIndexEntity> FromDomain(IEnumerable<MeasurementIndex> domain)
            => domain.Select(FromDomain).ToHashSet();
        
        public static ISet<MeasurementIndex> ToDomain(IEnumerable<MeasurementIndexEntity> entities)
            => entities.Select(entity => entity.ToDomain()).ToHashSet();

        #endregion
    }
}
