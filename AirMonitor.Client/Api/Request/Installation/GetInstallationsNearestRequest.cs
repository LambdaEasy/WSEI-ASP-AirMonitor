using System.Collections.Generic;

namespace AirMonitor.Client.Api.Request.Installation
{
    public readonly struct GetInstallationsNearestRequest
    {
        #region Fields
        
        private const string LatitudeTag = "lat";
        private const string LongitudeTag = "lng";
        private const string MaxDistanceKmTag = "maxDistanceKm";
        private const string MaxResultsTag = "maxResults";

        /// <summary>
        /// Latitude
        /// </summary>
        private readonly double _latitude;
        
        /// <summary>
        /// Logitude
        /// </summary>
        private readonly double _longitude;
        
        /// <summary>
        /// Max distance in km. Negative values mean 'infinity' (no distance limit).
        /// Optional parameter, if omitted defaults to 3km.
        /// </summary>
        private readonly double? _maxDistanceKm;
        
        /// <summary>
        /// Max results to return. Negative values mean 'infinity' (no results limit).
        /// Optional parameter, if omitted defaults to 1 item.
        /// </summary>
        private readonly int? _maxResults;

        #endregion

        #region Constructors

        private GetInstallationsNearestRequest(double latitude,
                                               double longitude,
                                               double? maxDistanceKm,
                                               int? maxResults)
        {
            _latitude = latitude;
            _longitude = longitude;
            _maxDistanceKm = maxDistanceKm;
            _maxResults = maxResults;
        }

        #endregion

        public IDictionary<string, object> ToQueryParams()
        {
            IDictionary<string, object> queryParams = new Dictionary<string, object>();

            queryParams.Add(LatitudeTag, _latitude);
            queryParams.Add(LongitudeTag, _longitude);

            // TODO [util] extension AddIfNotNull
            if (_maxDistanceKm != null)
            {
                queryParams.Add(MaxDistanceKmTag, _maxDistanceKm);
            }
            if (_maxResults != null)
            {
                queryParams.Add(MaxResultsTag, _maxResults);
            }

            return queryParams;
        }

        #region StaticConstructors

        public static GetInstallationsNearestRequest Create(double latitude, double longitude)
            => new GetInstallationsNearestRequest(latitude, longitude, null, null);
        
        public static GetInstallationsNearestRequest Create(double latitude, double longitude, double maxDistanceKm)
            => new GetInstallationsNearestRequest(latitude, longitude, maxDistanceKm, null);
        
        public static GetInstallationsNearestRequest Create(double latitude, double longitude, int maxResults)
            => new GetInstallationsNearestRequest(latitude, longitude, null, maxResults);

        public static GetInstallationsNearestRequest Create(double latitude,
                                                            double longitude,
                                                            double maxDistanceKm,
                                                            int maxResults)
            => new GetInstallationsNearestRequest(latitude, longitude, maxDistanceKm, maxResults);
        
        #endregion
    }
}
