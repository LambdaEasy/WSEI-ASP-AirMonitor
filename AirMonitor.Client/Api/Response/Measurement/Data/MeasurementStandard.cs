using System;
using AirMonitor.Client.Api.Response.Measurement.Definition;

namespace AirMonitor.Client.Api.Response.Measurement.Data
{
    public class MeasurementStandard : IEquatable<MeasurementStandard>
    {
        #region Fields

        public string Name { get; set; }
        public MeasurementValueTypeName Pollutant { get; set; }
        public double Limit { get; set; }
        public double Percent { get; set; }
        public string Averaging { get; set; }

        #endregion

        #region Constructors

        public MeasurementStandard()
        {
            // serializer
        }

        public MeasurementStandard(string name,
                                   MeasurementValueTypeName pollutant,
                                   double limit,
                                   double percent,
                                   string averaging)
        {
            Name = name;
            Pollutant = pollutant;
            Limit = limit;
            Percent = percent;
            Averaging = averaging;
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
            => HashCode.Combine(Name, (int) Pollutant, Limit, Percent, Averaging);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(name={Name}, " +
                   $"pollutant={Pollutant}, " +
                   $"limit={Limit}, " +
                   $"percent={Percent}, " +
                   $"averaging={Averaging}" +
               ")";
    }
}