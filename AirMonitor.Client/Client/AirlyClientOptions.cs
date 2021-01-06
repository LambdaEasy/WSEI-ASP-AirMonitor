using AirMonitor.Client.Api;
using AirMonitor.Client.Util;

namespace AirMonitor.Client.Client
{
    public class AirlyClientOptions
    {
        private readonly IAirlyClientConfig _config;

        private AirlyClientOptions(IAirlyClientConfig config)
        {
            _config = config;
        }

        public string GetUrl(AirlyClientFunction function, string query)
            => AirlyClientUrlBuilder.GetUrl(_config.IsSecure,
                                            _config.HostAddress,
                                            _config.ApiPrefix,
                                            _config.ApiVersion,
                                            function.ApiPath,
                                            query);
        
        public static AirlyClientOptions Create(IAirlyClientConfig config)
            => new AirlyClientOptions(config);
    }
}
