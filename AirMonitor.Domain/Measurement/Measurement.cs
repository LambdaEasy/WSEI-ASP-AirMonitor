using System;
using System.Collections.Generic;

namespace AirMonitor.Domain.Measurement
{
    public class Measurement : IEquatable<Measurement>
    {
        #region Fields
        
        public long? Id { get; set; }
        public DateTimeOffset UpdateDateTime { get; set; }
        public DateTimeOffset FromDateTime { get; set; }
        public DateTimeOffset TillDateTime { get; set; }
        public ISet<MeasurementValue> Values { get; set; }
        public ISet<MeasurementIndex> Indexes { get; set; }
        public ISet<MeasurementStandard> Standards { get; set; }

        public bool IsValid => TillDateTime > DateTimeOffset.Now;

        #endregion

        #region Constructors

        public Measurement(long? id,
                           DateTimeOffset updateDateTime,
                           DateTimeOffset fromDateTime,
                           DateTimeOffset tillDateTime,
                           ISet<MeasurementValue> values,
                           ISet<MeasurementIndex> indexes,
                           ISet<MeasurementStandard> standards)
        {
            this.Id = id;
            this.UpdateDateTime = updateDateTime;
            this.FromDateTime = fromDateTime;
            this.TillDateTime = tillDateTime;
            this.Values = values;
            this.Indexes = indexes;
            this.Standards = standards;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(Measurement other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Id.Equals(other.Id)
                && UpdateDateTime.Equals(other.UpdateDateTime)
                && FromDateTime.Equals(other.FromDateTime) 
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
            return Equals((Measurement) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, UpdateDateTime, FromDateTime, TillDateTime, Values, Indexes, Standards);

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

        public static Measurement Create(DateTimeOffset updateDateTime,
                                         DateTimeOffset fromDateTime,
                                         DateTimeOffset tillDateTime,
                                         ISet<MeasurementValue> values,
                                         ISet<MeasurementIndex> indexes,
                                         ISet<MeasurementStandard> standards)
            => new Measurement(null, updateDateTime, fromDateTime, tillDateTime, values, indexes, standards);

        #endregion
    }
}
