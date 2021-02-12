using System;

namespace AirMonitor.Domain.Measurement
{
    public class MeasurementValue : IEquatable<MeasurementValue>
    {
        #region Fields

        public MeasurementValueType Type { get; set; }
        public double Value { get; set; }

        #endregion

        #region Constructors

        public MeasurementValue(MeasurementValueType type, double value)
        {
            this.Type = type;
            this.Value = Value;
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
            return Equals(Type, other.Type) && Value.Equals(other.Value);
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
            => HashCode.Combine(Type, Value);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(type={Type}, value={Value})";

        #region StaticConstructors

        public static MeasurementValue Create(MeasurementValueTypeName typeName, double value)
            => new MeasurementValue(MeasurementValueType.GetForName(typeName), value);

        #endregion
    }
}
