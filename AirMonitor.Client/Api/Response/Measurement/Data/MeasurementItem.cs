using System;
using System.Collections.Generic;

namespace AirMonitor.Client.Api.Response.Measurement.Data
{
    public class MeasurementItem : IEquatable<MeasurementItem>
    {
        #region Fields

        /// <summary>
        /// Time when measurement was taken.
        /// </summary>
        public DateTimeOffset FromDateTime { get; set; }

        /// <summary>
        /// Time until which this measurement is valid.
        /// </summary>
        public DateTimeOffset TillDateTime { get; set; }
        
        /// <summary>
        /// Measurement item values.
        /// </summary>
        public ISet<MeasurementValue> Values { get; set; }
        
        /// <summary>
        /// Measurement indexes.
        /// </summary>
        public ISet<MeasurementIndex> Indexes { get; set; }
        
        /// <summary>
        /// MeasurementStandards.
        /// </summary>
        public ISet<MeasurementStandard> Standards { get; set; }
        
        #endregion

        #region Constructors

        public MeasurementItem()
        {
            // serializer
        }

        public MeasurementItem(DateTimeOffset fromDateTime,
                               DateTimeOffset tillDateTime,
                               ISet<MeasurementValue> values,
                               ISet<MeasurementIndex> indexes,
                               ISet<MeasurementStandard> standards)
        {
            FromDateTime = fromDateTime;
            TillDateTime = tillDateTime;
            Values = values;
            Indexes = indexes;
            Standards = standards;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementItem other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return FromDateTime.Equals(other.FromDateTime)
                && TillDateTime.Equals(other.TillDateTime)
                && Equals(Values, other.Values)
                && Equals(Indexes, other.Indexes)
                && Equals(Standards, other.Standards);
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
            return Equals((MeasurementItem) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(FromDateTime, TillDateTime, Values, Indexes, Standards);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"fromDateTime={FromDateTime}, " +
                   $"tillDateTime={TillDateTime}, " +
                   $"values={Values}, " +
                   $"indexes={Indexes}, " +
                   $"standards={Standards}" +
               ")";
    }
}

