namespace AirMonitor.Core.Measurement
{
    public class MeasurementError
    {
        # region Constants
        
        private const MeasurementErrorCode DefaultCode = MeasurementErrorCode.Unknown;
        private const string DefaultMessage = "Unknown MeasurementError occured.";
        private const string DuplicateMessagePattern = "Measurement already exists for {0} = {1}.";
        private const string NotFoundMessagePattern = "Measurement not found by {0} = {1}.";
        

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

        public static MeasurementError UnknownError() 
            => new MeasurementError(DefaultCode, DefaultMessage);

        public static MeasurementError DuplicateId(long id)
            => new MeasurementError(MeasurementErrorCode.DuplicateId, string.Format(DuplicateMessagePattern, "id", id));

        public static MeasurementError DuplicateExternalId(long externalId)
            => new MeasurementError(MeasurementErrorCode.DuplicateExternalId, string.Format(DuplicateMessagePattern, "externalId", externalId));

        public static MeasurementError NotFoundById(long id)
            => new MeasurementError(MeasurementErrorCode.NotFoundById, string.Format(NotFoundMessagePattern, "id", id));

        public static MeasurementError NotFoundByExternalId(long externalId)
            => new MeasurementError(MeasurementErrorCode.NotFoundByExternalId, string.Format(NotFoundMessagePattern, "externalId", externalId));

        #endregion
    }
}
