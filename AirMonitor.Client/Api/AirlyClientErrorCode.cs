namespace AirMonitor.Client.Api
{
    public enum AirlyClientErrorCode
    {
        Unknown,
        
        AirlyApiBadRequest,
        AirlyApiRequestLimitExceeded,
        AirlyApiInternalServerError,
        AirlyApiAuthorizationFailed,
        AirlyApiNotFound
    }
}
