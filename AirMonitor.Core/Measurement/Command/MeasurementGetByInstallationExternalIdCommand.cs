using System;

namespace AirMonitor.Core.Measurement.Command
{
    public readonly struct MeasurementGetByInstallationExternalIdCommand : IEquatable<MeasurementGetByInstallationExternalIdCommand>
    {
        #region Fields

        public long InstallationExternalId => _installationExternalId;

        private readonly long _installationExternalId;

        #endregion

        #region Constructor

        private MeasurementGetByInstallationExternalIdCommand(long installationExternalId)
        {
            _installationExternalId = installationExternalId;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementGetByInstallationExternalIdCommand other)
            => _installationExternalId == other._installationExternalId;

        public override bool Equals(object obj)
            => obj is MeasurementGetByInstallationExternalIdCommand other && Equals(other);

        public override int GetHashCode()
            => _installationExternalId.GetHashCode();

        #endregion

        public override string ToString()
            => $"{GetType().Name}(installationExternalId={_installationExternalId})";

        #region StaticConstructors

        public static MeasurementGetByInstallationExternalIdCommand Create(long installationExternalId)
            => new MeasurementGetByInstallationExternalIdCommand(installationExternalId);

        #endregion
    }
}