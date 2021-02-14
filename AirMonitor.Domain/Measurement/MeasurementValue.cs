using System;

namespace AirMonitor.Domain.Measurement
{
    public class MeasurementValue : IEquatable<MeasurementValue>
    {
        #region Fields

        public long? Id { get; set; }
        public MeasurementValueType Type { get; set; }
        public double Value { get; set; }

        #endregion

        #region Constructors

        public MeasurementValue(long? id, MeasurementValueType type, double value)
        {
            this.Id = id;
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
            return Equals(Id, other.Id) && Equals(Type, other.Type) && Value.Equals(other.Value);
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
            => $"{GetType().Name}(id={Id}, type={Type}, value={Value})";

        #region StaticConstructors

        public static MeasurementValue Create(MeasurementValueTypeName typeName, double value)
            => new MeasurementValue(null, MeasurementValueType.GetForName(typeName), value);

        #endregion
    }
}
