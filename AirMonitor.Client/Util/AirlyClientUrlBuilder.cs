using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace AirMonitor.Client.Util
{
    public static class AirlyClientUrlBuilder
    {
        public static string GetUrl(bool isSecure,
                                    string hostAddress,
                                    string apiPrefix,
                                    string apiVersion,
                                    string apiPath,
                                    string query)
        {
            var apiUrl = $"{GetProtocol(isSecure)}://{hostAddress}/{GetApiPrefix(apiPrefix)}{apiVersion}/";
            var builder = new UriBuilder(apiUrl);
            builder.Port = -1;
            builder.Path += apiPath;
            builder.Query = query;
            
            return builder.ToString();
        }

        public static Uri GetBaseUrl(IAirlyClientConfig config)
            => new Uri(GetBaseUrl(config.IsSecure,
                                  config.HostAddress,
                                  config.HostPort,
                                  config.ApiPrefix,
                                  config.ApiVersion));

        // TODO [client] this method is a pure guess, validate and refactor
        public static string GetQuery(IDictionary<string, object> queryParams)
        {
            if (queryParams == null)
            {
                return null;
            }

            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var arg in queryParams)
            {
                if (arg.Value is double number)
                {
                    query[arg.Key] = number.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    query[arg.Key] = arg.Value?.ToString();
                }
            }
            return query.ToString();
        }

        private static string GetBaseUrl(bool isSecure,
                                        string hostAddress,
                                        string hostPort,
                                        string apiPrefix,
                                        string apiVersion) 
            => $"{GetProtocol(isSecure)}://{hostAddress}{GetHostPort(hostPort)}/{GetApiPrefix(apiPrefix)}{apiVersion}/";

        private static string GetHostPort(string hostPort)
            => hostPort != null ? $":{hostPort}" : "";

        private static string GetProtocol(bool isSecure) => isSecure ? "https" : "http";

        private static string GetApiPrefix(string apiPrefix) => string.IsNullOrEmpty(apiPrefix) ?  "" : $"{apiPrefix}/";
    }
}
