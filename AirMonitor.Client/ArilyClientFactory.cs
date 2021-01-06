using System.Net.Http;
using AirMonitor.Client.Client;
using AirMonitor.Client.Util;

// TODO log
namespace AirMonitor.Client
{
    public static class ArilyClientFactory
    {
        public static IAirlyClient Create(IAirlyClientConfig config)
            => new AirlyClient(CreateHttpClient(config), CreateOptions(config));

        private static HttpClient CreateHttpClient(IAirlyClientConfig config)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = AirlyClientUrlBuilder.GetBaseUrl(config);
            InterceptDefaultHttpHeaders(httpClient);
            InterceptAuthorizationHttpHeaders(httpClient, config);

            return httpClient;
        }

        // TODO [client] interceptor?
        private static void InterceptDefaultHttpHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        // TODO [client] interceptor?
        private static void InterceptAuthorizationHttpHeaders(HttpClient httpClient, IAirlyClientConfig config)
        {
            httpClient.DefaultRequestHeaders.Add(config.ApiAuthKey, config.ApiAuthValue);
        }

        private static AirlyClientOptions CreateOptions(IAirlyClientConfig config)
            => AirlyClientOptions.Create(config);
    }
}
