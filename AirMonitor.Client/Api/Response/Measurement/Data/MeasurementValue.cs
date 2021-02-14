using System;
using AirMonitor.Client.Api.Response.Measurement.Definition;

namespace AirMonitor.Client.Api.Response.Measurement.Data
{
    public class MeasurementValue : IEquatable<MeasurementValue>
    {
        #region Fields

        public MeasurementValueTypeName Name { get; set; }
        public double Value { get; set; }

        public MeasurementValueType Type => MeasurementValueType.GetForName(Name);

        #endregion

        #region Constructors

        public MeasurementValue()
        {
            // serializer
        }

        public MeasurementValue(MeasurementValueTypeName name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementValue other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && Value.Equals(other.Value);
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
            return Equals((MeasurementValue) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine((int) Name, Value);

        #endregion

        #region ToString

        public override string ToString()
            => $"MeasurementValue(type={Type}, value={Value})";

        #endregion

    }
}
