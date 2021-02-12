using System;
using System.Collections.Generic;

namespace AirMonitor.Domain.Measurement.Dto
{
    public class MeasurementDto : IEquatable<MeasurementDto>
    {
        #region Fields

        public long Id => _id;
        public DateTimeOffset UpdateDateTime => _updateDateTime;
        public DateTimeOffset FromDateTime => _fromDateTime;
        public DateTimeOffset TillDateTime => _tillDateTim;
        public ISet<MeasurementValueDto> Values => _values;
        public ISet<MeasurementIndexDto> Indexes => _indexes;
        public ISet<MeasurementStandardDto> Standards => _standards;

        private readonly long _id;
        private readonly DateTimeOffset _updateDateTime;
        private readonly DateTimeOffset _fromDateTime;
        private readonly DateTimeOffset _tillDateTim;
        private readonly ISet<MeasurementValueDto> _values;
        private readonly ISet<MeasurementIndexDto> _indexes;
        private readonly ISet<MeasurementStandardDto> _standards;

        #endregion

        #region Constructors

        private MeasurementDto(long id,
                               DateTimeOffset updateDateTime,
                               DateTimeOffset fromDateTime,
                               DateTimeOffset tillDateTim,
                               ISet<MeasurementValueDto> values,
                               ISet<MeasurementIndexDto> indexes,
                               ISet<MeasurementStandardDto> standards)
        {
            this._id = id;
            this._updateDateTime = updateDateTime;
            this._fromDateTime = fromDateTime;
            this._tillDateTim = tillDateTim;
            this._values = values;
            this._indexes = indexes;
            this._standards = standards;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _id.Equals(other._id)
                && _updateDateTime.Equals(other._updateDateTime)
                && _fromDateTime.Equals(other._fromDateTime)
                && _tillDateTim.Equals(other._tillDateTim)
                && Equals(_values, other._values)
                && Equals(_indexes, other._indexes)
                && Equals(_standards, other._standards);
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
            return Equals((MeasurementDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(_id, _updateDateTime, _fromDateTime, _tillDateTim, _values, _indexes, _standards);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"id={Id}, " +
                   $"updateDateTime={UpdateDateTime}, " +
                   $"fromDateTime={FromDateTime}, " +
                   $"tillDateTime={TillDateTime}, " +
                   $"values={Values}, " +
                   $"indexes={Indexes}, " +
                   $"standards={Standards}" +
               ")";

        #region StaticConstructors

        public static MeasurementDto FromDomain(Measurement domain)
            => new MeasurementDto(domain.Id ?? throw new ArgumentException("Id is null"),
                                  domain.UpdateDateTime,
                                  domain.FromDateTime,
                                  domain.TillDateTime,
                                  MeasurementValueDto.FromDomain(domain.Values),
                                  MeasurementIndexDto.FromDomain(domain.Indexes),
                                  MeasurementStandardDto.FromDomain(domain.Standards));

        #endregion
    }
}
