namespace AirMonitor.Core.Installation.Command
{
    public readonly struct InstallationDeleteCommand
    {
        #region Fields

        public DeleteType Type => _type;
        public long Id => _id;

        private readonly DeleteType _type;
        private readonly long _id;

        #endregion

        #region Constructors

        private InstallationDeleteCommand(DeleteType type, long id)
        {
            _type = type;
            _id = id;
        }

        #endregion

        public override string ToString()
            => $"InstallationDeleteCommand(type={_type}, id={_id})";

        #region StaticConstructors

        public InstallationDeleteCommand Soft(long id)
            => new InstallationDeleteCommand(DeleteType.Soft, id);

        #endregion

        public enum DeleteType
        {
            Soft,
            Hard
        }
    }
}