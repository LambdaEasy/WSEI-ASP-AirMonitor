using System.Collections.Generic;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Util.Flow;

namespace AirMonitor.Core.Installation
{
    public interface IInstallationClient
    {
        /// <summary>
        /// Queries external api for installation nearby given command.
        /// </summary>
        /// <param name="command">Command consisting of all required data to perform api search.</param>
        /// <returns>Either a list of installations or an error that occured.</returns>
        Either<InstallationError, IEnumerable<InstallationCreateCommand>> GetInstallationsNearby(InstallationGetAllNearbyCommand command);
    }
}
