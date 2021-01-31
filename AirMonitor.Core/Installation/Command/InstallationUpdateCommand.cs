using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Core.Installation.Command
{
    // TODO temporary class before Measurements implementation
    public readonly struct InstallationUpdateCommand
    {
        #region Fields

        private readonly InstallationDto _installation;

        #endregion

        #region Constructors

        private InstallationUpdateCommand(InstallationDto installation)
        {
            this._installation = installation;
        }

        #endregion

        public Either<InstallationError, InstallationDto> TemporaryDevResultFunction()
            => Either<InstallationError, InstallationDto>.Right<InstallationError, InstallationDto>(_installation);
        
        public override string ToString()
            => $"InstallationUpdateCommand(installation={_installation})";

        #region StaticConstructors

        public static InstallationUpdateCommand TemporaryDevCreate(InstallationDto installation)
            => new InstallationUpdateCommand(installation);

        #endregion
    }
}
