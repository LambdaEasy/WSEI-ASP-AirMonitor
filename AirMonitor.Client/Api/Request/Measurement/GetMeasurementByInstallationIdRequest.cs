using System.Collections.Generic;
using AirMonitor.Client.Api.Response.Measurement.Definition;

namespace AirMonitor.Client.Api.Request.Measurement
{
    public class GetMeasurementByInstallationIdRequest
    {
        #region Fields

        private const bool DefaultIncludeWind = true;
        private const MeasurementIndexName DefaultIndexType = MeasurementIndexName.AIRLY_CAQI;

        private static string IncludeWindTag = "includeWind";
        private const string IndexTypeTag = "indexType"; 
        private const string InstallationIdTag = "installationId";

        /// <summary>
        /// Select whether to include wind in response or not.
        /// </summary>
        public readonly bool _includeWind;

        /// <summary>
        /// Select index which should be returned in response.
        /// </summary>
        public readonly MeasurementIndexName _indexType;

        /// <summary>
        /// AirlyInstallation ID.
        /// </summary>
        public readonly long _installationId;

        #endregion

        #region Constructors

        private GetMeasurementByInstallationIdRequest(bool includeWind,
                                                      MeasurementIndexName indexType,
                                                      long installationId)
        {
            _includeWind = includeWind;
            _indexType = indexType;
            _installationId = installationId;
        }

        #endregion
        
        public IDictionary<string, object> ToQueryParams()
        {
            IDictionary<string, object> queryParams = new Dictionary<string, object>();

            queryParams.Add(IncludeWindTag, _includeWind);
            queryParams.Add(IndexTypeTag, _indexType);
            queryParams.Add(InstallationIdTag, _installationId);

            return queryParams;
        }

        #region StaticConstructors

        public static GetMeasurementByInstallationIdRequest Create(long installationId)
            => new GetMeasurementByInstallationIdRequest(DefaultIncludeWind, DefaultIndexType, installationId);

        #endregion
    }
}
