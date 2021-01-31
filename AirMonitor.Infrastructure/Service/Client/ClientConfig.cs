using AirMonitor.Client;

namespace AirMonitor.Infrastructure.Service.Client
{
    public class ClientConfig : IAirlyClientConfig
    {
        #region Fields

        public bool IsSecure { get; set; }
        public string HostAddress { get; set; }
        public string HostPort { get; set; }
        public string ApiPrefix { get; set; }
        public string ApiVersion { get; set; }
        public string ApiAuthKey { get; set; }
        public string ApiAuthValue { get; set; }

        #endregion

        #region Constructors
        
        public ClientConfig()
        {
            // for serialization
        }

        public ClientConfig(bool isSecure,
                            string hostAddress,
                            string hostPort,
                            string apiPrefix,
                            string apiVersion,
                            string apiAuthKey,
                            string apiAuthValue)
        {
            IsSecure = isSecure;
            HostAddress = hostAddress;
            HostPort = hostPort;
            ApiPrefix = apiPrefix;
            ApiVersion = apiVersion;
            ApiAuthKey = apiAuthKey;
            ApiAuthValue = apiAuthValue;
        }
        
        #endregion
    }
}
