using System;
using System.Collections.Generic;
using System.Linq;

namespace AirMonitor.Domain.Measurement.Dto
{
    public class MeasurementStandardDto : IEquatable<MeasurementStandardDto>
    {
        #region Fields

        public long Id => _id;
        public string Name => _name;
        public MeasurementValueType Pollutant => _pollutant;
        public double Limit => _limit;
        public double Percent => _percent;
        public string Averaging => _averaging;

        private readonly long _id;
        private readonly string _name;
        private readonly MeasurementValueType _pollutant;
        private readonly double _limit;
        private readonly double _percent;
        private readonly string _averaging;

        #endregion

        #region Constructors

        private MeasurementStandardDto(long id,
                                       string name,
                                       MeasurementValueType pollutant,
                                       double limit,
                                       double percent,
                                       string averaging)
        {
            this._id = id;
            this._name = name;
            this._pollutant = pollutant;
            this._limit = limit;
            this._percent = percent;
            this._averaging = averaging;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementStandardDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _id == other._id
                && _name == other._name
                && Equals(_pollutant, other._pollutant)
                && _limit.Equals(other._limit)
                && _percent.Equals(other._percent)
                && _averaging == other._averaging;
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
            return Equals((MeasurementStandardDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_name, _pollutant, _limit, _percent, _averaging);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"id={Id}, " +
                   $"name={Name}, " +
                   $"pollutant={Pollutant}, " +
                   $"limit={Limit}, " +
                   $"percent={Percent}, " +
                   $"averaging={Averaging}" +
               ")";

        #region StaticConstructors

        public static MeasurementStandardDto FromDomain(MeasurementStandard domain)
            => new MeasurementStandardDto(domain.Id ?? throw new ArgumentException("Id is null"),
                                          domain.Name,
                                          domain.Pollutant,
                                          domain.Limit,
                                          domain.Percent,
                                          domain.Averaging);

        public static ISet<MeasurementStandardDto> FromDomain(IEnumerable<MeasurementStandard> domain)
            => domain.Select(FromDomain).ToHashSet();

        #endregion
    }
}
