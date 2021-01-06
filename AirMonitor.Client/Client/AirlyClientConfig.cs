namespace AirMonitor.Client.Client
{
    public class AirlyClientConfig : IAirlyClientConfig
    {
        #region Fields

        public bool IsSecure => _isSecure;
        public string HostAddress => _hostAddress;
        public string HostPort => _hostPort;
        public string ApiPrefix => _apiPrefix;
        public string ApiVersion => _apiVersion;
        public string ApiAuthKey => _apiAuthKey;
        public string ApiAuthValue => _apiAuthValue;

        private readonly bool _isSecure;
        private readonly string _hostAddress;
        private readonly string _hostPort;
        private readonly string _apiPrefix;
        private readonly string _apiVersion;
        private readonly string _apiAuthKey;
        private readonly string _apiAuthValue;

        #endregion

        #region Constructors

        private AirlyClientConfig(bool isSecure,
                                  string hostAddress,
                                  string hostPort,
                                  string apiPrefix,
                                  string apiVersion,
                                  string apiAuthKey,
                                  string apiAuthValue)
        {
            _isSecure = isSecure;
            _hostAddress = hostAddress;
            _hostPort = hostPort;
            _apiPrefix = apiPrefix;
            _apiVersion = apiVersion;
            _apiAuthKey = apiAuthKey;
            _apiAuthValue = apiAuthValue;
        }

        #endregion

        #region StaticConstructors

        public static IAirlyClientConfig Create(bool isSecure,
                                                string hostAddress,
                                                string hostPort,
                                                string apiPrefix,
                                                string apiVersion,
                                                string apiAuthKey,
                                                string apiAuthValue)
            => new AirlyClientConfig(isSecure, hostAddress, hostPort, apiPrefix, apiVersion, apiAuthKey, apiAuthValue);

        #endregion

    }
}
