namespace AirMonitor.Core.Installation
{
    public class InstallationError
    {
        # region Constants

        private const InstallationErrorCode DefaultCode = InstallationErrorCode.Unknown;
        private const string DefaultMessage = "Unknown InstallationError occured.";
        private const string NotFoundMessagePattern = "Installation not found by {0} = {1}.";
        private const string DuplicateMessagePattern = "Installation already exists for {0} = {1}.";
        private const string ClientErrorMessagePattern = "Installation could not be loaded from external client, reason = {0}.";
        

        #endregion

        #region Fields

        public InstallationErrorCode Code => _code;
        public string Message => _message;

        public readonly InstallationErrorCode _code;
        public readonly string _message;

        #endregion

        #region Constructors

        private InstallationError(InstallationErrorCode code, string message)
        {
            _code = code;
            _message = message;
        }

        #endregion

        #region StaticConstructors

        public InstallationError UnknownError() 
            => new InstallationError(DefaultCode, DefaultMessage);

        public static InstallationError NotFoundById(long id)
            => new InstallationError(InstallationErrorCode.NotFound, string.Format(NotFoundMessagePattern, "id", id));

        public static InstallationError NotFoundByExternalId(long id)
            => new InstallationError(InstallationErrorCode.NotFound, string.Format(NotFoundMessagePattern, "externalId", id));
        
        public static InstallationError DuplicateExternalId(long externalId)
            => new InstallationError(InstallationErrorCode.Duplicate, string.Format(DuplicateMessagePattern, "externalId", externalId));

        public static InstallationError ClientError(string clientErrorMessage)
            => new InstallationError(InstallationErrorCode.ClientError, string.Format(ClientErrorMessagePattern, clientErrorMessage));

        #endregion
    }
}
