using System;
using AirMonitor.Client.Api.Response.Measurement.Data;

namespace AirMonitor.Client.Api.Response.Measurement
{
    public class GetMeasurementByInstallationIdResponse : IEquatable<GetMeasurementByInstallationIdResponse>
    {
        #region Fields

        public MeasurementItem Current { get; set; }

        // Returned by api, not used by AirMonitor, omitted in POJO
        // public ISet<MeasurementItem> History { get; set; }

        // Returned by api, not used by AirMonitor, omitted in POJO
        // public ISet<MeasurementItem> Forecast { get; set; }

        #endregion

        #region Constructors

        public GetMeasurementByInstallationIdResponse()
        {
            // serializer
        }

        public GetMeasurementByInstallationIdResponse(MeasurementItem current)
        {
            Current = current;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(GetMeasurementByInstallationIdResponse other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(Current, other.Current);
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
            return Equals((GetMeasurementByInstallationIdResponse) obj);
        }

        public override int GetHashCode()
            => (Current != null ? Current.GetHashCode() : 0);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(current={Current})";
    }
}
