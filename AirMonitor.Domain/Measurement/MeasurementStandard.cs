using System;

namespace AirMonitor.Domain.Measurement
{
    public class MeasurementStandard : IEquatable<MeasurementStandard>
    {
        #region Fields

        public long? Id { get; set; }
        public string Name { get; set; }
        public MeasurementValueType Pollutant { get; set; }
        public double Limit { get; set; }
        public double Percent { get; set; }
        public string Averaging { get; set; }

        #endregion

        #region Constructors

        public MeasurementStandard(long? id,
                                   string name,
                                   MeasurementValueType pollutant,
                                   double limit,
                                   double percent,
                                   string averaging)
        {
            this.Id = id;
            this.Name = name;
            this.Pollutant = pollutant;
            this.Limit = limit;
            this.Percent = percent;
            this.Averaging = averaging;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementStandard other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Id == other.Id
                && Name == other.Name
                && Pollutant == other.Pollutant
                && Limit.Equals(other.Limit)
                && Percent.Equals(other.Percent)
                && Averaging == other.Averaging;
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
            return Equals((MeasurementStandard) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, Name, Pollutant, Limit, Percent, Averaging);

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

        public static MeasurementStandard Create(string name,
                                                 MeasurementValueTypeName pollutantName,
                                                 double limit,
                                                 double percent,
                                                 string averaging)
            => new MeasurementStandard(null, name, MeasurementValueType.GetForName(pollutantName), limit, percent, averaging);

        #endregion
    }
}
