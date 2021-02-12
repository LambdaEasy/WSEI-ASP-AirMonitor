namespace AirMonitor.Core.Measurement
{
    public class MeasurementError
    {
        # region Constants

        // TODO example below
        // private const string ClientErrorMessagePattern = "Installation could not be loaded from external client, reason = {0}.";

        #endregion

        #region Fields

        public MeasurementErrorCode Code => _code;
        public string Message => _message;

        public readonly MeasurementErrorCode _code;
        public readonly string _message;

        #endregion

        #region Constructors

        private MeasurementError(MeasurementErrorCode code, string message)
        {
            _code = code;
            _message = message;
        }

        #endregion
        
        public override string ToString()
            => $"{GetType().Name}(code={_code}, message={_message})";

        #region StaticConstructors

        // TODO example below
        // public InstallationError UnknownError() 
        //     => new InstallationError(DefaultCode, DefaultMessage);

        #endregion
    }
}
