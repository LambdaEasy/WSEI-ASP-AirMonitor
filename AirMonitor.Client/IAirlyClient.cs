using System.Collections.Generic;
using System.Threading.Tasks;
using AirMonitor.Client.Api;
using AirMonitor.Client.Api.Request.Installation;
using AirMonitor.Client.Api.Response.Installation;
using AirMonitor.Util.Flow;

namespace AirMonitor.Client
{
    public interface IAirlyClient
    {
        /// <summary>
        /// Given query data searches arily api for closes installations.
        /// </summary>
        /// <param name="request">Installations query data</param>
        /// <returns>List of found installations or Error which occured.</returns>
        Task<Either<AirlyClientError, IEnumerable<GetInstallationsNearestResponse>>> GetInstallationsNearest(GetInstallationsNearestRequest request);
    }
}
