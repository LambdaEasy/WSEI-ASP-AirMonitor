using System;
using System.Collections.Generic;
using System.Linq;

namespace AirMonitor.Domain.Measurement.Dto
{
    public class MeasurementValueDto : IEquatable<MeasurementValueDto>
    {
        #region Fields

        public long Id => _id;
        public MeasurementValueType Type => _type;
        public double Value => _value;

        private readonly long _id;
        private readonly MeasurementValueType _type;
        private readonly double _value;

        #endregion

        #region Constructors

        private MeasurementValueDto(long id, MeasurementValueType type, double value)
        {
            this._id = id;
            this._type = type;
            this._value = value;
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
            return Equals(_id, other._id) && Equals(_type, other._type) && _value.Equals(other._value);
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
            => $"{GetType().Name}(id={Id}, type={Type}, value={Value})";

        #region StaticConstructors

        public static MeasurementValueDto FromDomain(MeasurementValue domain)
            => new MeasurementValueDto(domain.Id ?? throw new ArgumentException("Id is null"),
                                       domain.Type,
                                       domain.Value);

        public static ISet<MeasurementValueDto> FromDomain(IEnumerable<MeasurementValue> domain)
            => domain.Select(FromDomain).ToHashSet();

        #endregion
    }
}
