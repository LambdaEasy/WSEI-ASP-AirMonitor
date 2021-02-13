namespace AirMonitor.Core.Measurement.Command
{
    public readonly struct MeasurementDeleteCommand
    {
        #region Fields

        public DeleteType Type => _type;
        public long Id => _id;

        private readonly DeleteType _type;
        private readonly long _id;

        #endregion

        #region Constructors

        private MeasurementDeleteCommand(DeleteType type, long id)
        {
            _type = type;
            _id = id;
        }

        #endregion

        public override string ToString()
            => $"{GetType().Name}(type={_type}, id={_id})";

        #region StaticConstructors

        public MeasurementDeleteCommand Soft(long id)
            => new MeasurementDeleteCommand(DeleteType.Soft, id);

        #endregion

        public enum DeleteType
        {
            Soft,
            Hard
        }
    }
}
