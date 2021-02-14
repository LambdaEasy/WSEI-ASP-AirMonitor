namespace AirMonitor.Client.Api
{
    public class AirlyClientError
    {
        #region Constants

        private const AirlyClientErrorCode DefaultCode = AirlyClientErrorCode.Unknown;
        private const string DefaultMessage = "Unknown error occured while calling airly api.";
        private const string BadRequestMessagePattern = "Unexpected error occured while calling airly api.";
        private const string RequestLimitExceededMessagePattern = "Airly client request limit exceeded, try latter.";
        private const string InternalServerErrorMessagePattern = "Airly server failed to respond (InternalServerError).";
        private const string AuthorizationFailedMessagePattern = "Airly server declined request due to invaild authorization headers.";
        private const string NotFoundFailedMessagePattern = "Airly server responded with resource not found.";

        #endregion

        #region Fields

        public AirlyClientErrorCode Code => _code;
        public string Message => _message;

        private readonly AirlyClientErrorCode _code;
        private readonly string _message;

        #endregion

        #region Constructors

        private AirlyClientError(AirlyClientErrorCode code, string message)
        {
            _code = code;
            _message = message;
        }

        #endregion

        public override string ToString()
            => $"AirlyClientError[({_code}) : {_message}]";

        #region StaticConstructors
        
        public static AirlyClientError Default()
            => new AirlyClientError(DefaultCode, DefaultMessage);

        public static AirlyClientError RequestLimitExceeded()
            => new AirlyClientError(AirlyClientErrorCode.AirlyApiRequestLimitExceeded, RequestLimitExceededMessagePattern);

        public static AirlyClientError BadRequest()
            => new AirlyClientError(AirlyClientErrorCode.AirlyApiBadRequest, BadRequestMessagePattern);
        
        public static AirlyClientError InternalServerError()
            => new AirlyClientError(AirlyClientErrorCode.AirlyApiInternalServerError, InternalServerErrorMessagePattern);
        
        public static AirlyClientError AuthorizationFailed()
            => new AirlyClientError(AirlyClientErrorCode.AirlyApiAuthorizationFailed, AuthorizationFailedMessagePattern);
        
        public static AirlyClientError NotFound()
            => new AirlyClientError(AirlyClientErrorCode.AirlyApiNotFound, NotFoundFailedMessagePattern);
        
        #endregion
        
    }
}
