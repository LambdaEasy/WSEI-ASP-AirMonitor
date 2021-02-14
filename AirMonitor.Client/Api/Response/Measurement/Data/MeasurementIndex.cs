using System;
using AirMonitor.Client.Api.Response.Measurement.Definition;

namespace AirMonitor.Client.Api.Response.Measurement.Data
{
    public class MeasurementIndex : IEquatable<MeasurementIndex>
    {
        #region Fields

        public MeasurementIndexName Name { get; set; }
        public double Value { get; set; }
        public MeasurementIndexLevel Level { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public string Color { get; set; }
        
        #endregion

        #region Constructor

        public MeasurementIndex()
        {
            // serializer
        }

        public MeasurementIndex(MeasurementIndexName name, double value, MeasurementIndexLevel level, string description, string advice, string color)
        {
            Name = name;
            Value = value;
            Level = level;
            Description = description;
            Advice = advice;
            Color = color;
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
            return Name == other.Name
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
            => HashCode.Combine(Name, Value, Level, Description, Advice, Color);

        #endregion

        public override string ToString()
            => "MeasurementIndex(" +
                   $"name={Name}, " +
                   $"value={Value}, " +
                   $"level={Level}, " +
                   $"description={Description}, " +
                   $"advice={Advice}, " +
                   $"color={Color}, " +
               ")";
    }
}
