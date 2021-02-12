using System;

namespace AirMonitor.Domain.Measurement
{
    public class MeasurementStandard : IEquatable<MeasurementStandard>
    {
        #region Fields

        public string Name { get; set; }
        public MeasurementValueType Pollutant { get; set; }
        public double Limit { get; set; }
        public double Percent { get; set; }
        public string Averaging { get; set; }

        #endregion

        #region Constructors

        public MeasurementStandard(string name,
                                   MeasurementValueType pollutant,
                                   double limit,
                                   double percent,
                                   string averaging)
        {
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
            return Name == other.Name
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
            => HashCode.Combine(Name, Pollutant, Limit, Percent, Averaging);

        #endregion

        #region StaticConstructors

        public static MeasurementStandard Create(string name,
                                                 MeasurementValueTypeName pollutantName,
                                                 double limit,
                                                 double percent,
                                                 string averaging)
            => new MeasurementStandard(name, MeasurementValueType.GetForName(pollutantName), limit, percent, averaging);

        #endregion
    }
}
