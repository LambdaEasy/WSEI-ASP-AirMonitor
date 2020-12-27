namespace AirMonitor.Core.Installation
{
    public class InstallationError
    {
        # region Constants

        private const InstallationErrorCode DefaultCode = InstallationErrorCode.Unknown;
        private const string DefaultMessage = "Unknown InstallationError occured.";
        private const string NotFoundMessagePattern = "Installation not found by {0} = {1}.";

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
        
        #endregion
    }
}
