using System;

namespace AirMonitor.Domain.Measurement
{
    public class MeasurementIndex : IEquatable<MeasurementIndex>
    {
        #region Fields

        public long? Id { get; set; }
        public MeasurementIndexName Name { get; set; }
        public double Value { get; set; }
        public MeasurementIndexLevel Level { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public string Color { get; set; }

        #endregion

        #region Constructors

        public MeasurementIndex(long? id,
                                MeasurementIndexName name,
                                double value,
                                MeasurementIndexLevel level,
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

        public bool Equals(MeasurementIndex other)
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
            return Equals((MeasurementIndex) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, (int) Name, Value, (int) Level, Description, Advice, Color);

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

        #region StaticConstructors

        public static MeasurementIndex Create(MeasurementIndexName name,
                                              double value,
                                              MeasurementIndexLevel level,
                                              string description,
                                              string advice,
                                              string color)
            => new MeasurementIndex(null, name, value, level, description, advice, color);

        #endregion
    }
}
