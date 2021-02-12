using System;
using System.Collections.Generic;
using System.Linq;

namespace AirMonitor.Domain.Measurement.Dto
{
    public class MeasurementValueDto : IEquatable<MeasurementValueDto>
    {
        #region Fields

        public MeasurementValueType Type => _type;
        public double Value => _value;

        private readonly MeasurementValueType _type;
        private readonly double _value;

        #endregion

        #region Constructors

        private MeasurementValueDto(MeasurementValueType type, double value)
        {
            _type = type;
            _value = value;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementValueDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(_type, other._type) && _value.Equals(other._value);
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
            return Equals((MeasurementValueDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_type, _value);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(type={Type}, value={Value})";

        #region StaticConstructors

        public static MeasurementValueDto FromDomain(MeasurementValue domain)
            => new MeasurementValueDto(domain.Type, domain.Value);

        public static ISet<MeasurementValueDto> FromDomain(IEnumerable<MeasurementValue> domain)
            => domain.Select(FromDomain).ToHashSet();

        #endregion
    }
}
