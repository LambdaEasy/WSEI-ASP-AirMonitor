using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AirMonitor.Client.Api;
using AirMonitor.Client.Api.Request.Installation;
using AirMonitor.Client.Api.Response.Installation;
using AirMonitor.Client.Util;
using AirMonitor.Util.Flow;
using Newtonsoft.Json;

namespace AirMonitor.Client.Client
{
    public class AirlyClient : IAirlyClient
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly AirlyClientOptions _options;

        #endregion

        #region Constructors

        public AirlyClient(HttpClient httpClient, AirlyClientOptions options)
        {
            this._httpClient = httpClient;
            this._options = options;
        }

        #endregion

        public async Task<Either<AirlyClientError, IEnumerable<GetInstallationsNearestResponse>>> GetInstallationsNearest(GetInstallationsNearestRequest request)
        {
            return await TracedOperation.CallAsync
            (
                "AirlyClient",
                AirlyClientFunction.AirlyClientFunctionType.GetInstallationsNearest,
                request,
                () =>
                {
                    string query = AirlyClientUrlBuilder.GetQuery(request.ToQueryParams());
                    string url = _options.GetUrl(AirlyClientFunction.GetInstallationsNearest, query);
                    return GetHttpResponseAsync<IEnumerable<GetInstallationsNearestResponse>>(url);
                }
            );
        }

        // TODO [log]
        // TODO [ref] separate to ApiClientResponseResolver
        // TODO [ref] errors when another api endpoints are added
        private async Task<Either<AirlyClientError, T>> GetHttpResponseAsync<T>(string url) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.Headers.TryGetValues("X-RateLimit-Limit-day", out var dayLimit) &&
                    response.Headers.TryGetValues("X-RateLimit-Remaining-day", out var dayLimitRemaining))
                {
                    // TODO [log]
                }

                switch ((int)response.StatusCode)
                {
                    // TODO handle 301 and 404
                    case 200:
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);
                        return Either<AirlyClientError, T>.Right<AirlyClientError, T>(result);

                    case 400:
                    case 405:
                    case 406:
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.BadRequest());
                    
                    case 401:
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.AuthorizationFailed());
                    
                    case 404:
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.NotFound());

                    case 429:
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.RequestLimitExceeded());
                    
                    case 500:
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.InternalServerError());

                    default:
                        // TODO [airly error] put airly error message into error
                        return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.Default()); 
                }
            }
            catch (Exception ex)
            {
                // TODO [airly error] handle different airly errors, communication, online, json parsing etc
                return Either<AirlyClientError, T>.Left<AirlyClientError, T>(AirlyClientError.Default());
            }
        }
    }
}
