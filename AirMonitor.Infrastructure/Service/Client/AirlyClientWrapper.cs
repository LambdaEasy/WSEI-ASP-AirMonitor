using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirMonitor.Client;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Infrastructure.Service.Client.Adapter;
using AirMonitor.Util.Flow;

namespace AirMonitor.Infrastructure.Service.Client
{
    public class AirlyClientWrapper : IInstallationClient
    {
        private const string LoggerName = "AirlyClientWrapper";

        private readonly IAirlyClient _airlyClient;

        private AirlyClientWrapper(IAirlyClient airlyClient)
        {
            this._airlyClient = airlyClient;
        }

        public Either<InstallationError, IEnumerable<InstallationCreateCommand>> GetInstallationsNearby(InstallationGetAllNearbyCommand command)
        {
            return TracedOperation.CallSync
            (
                LoggerName,
                ClientOperationType.GetNearbyInstallations,
                command,
                () => SynchronizeHttpCall // TODO move this to `TracedOperationClass` cos like that it kills a purpose of this class xD
                      (
                          _airlyClient.GetInstallationsNearest(AirMonitorToAirlyClientAdapter.FromCommand(command))
                      )
            )
            .Map(AirlyClientToAirMonitorAdapter.FromResponse)
            .MapLeft(AirlyClientToAirMonitorAdapter.ErrorFromResponse);
        }

        private static T SynchronizeHttpCall<T>(Task<T> httpCall)
            => httpCall.GetAwaiter().GetResult();
        
        #region StaticConstructors

        public static class Factory
        {
            public static IInstallationClient Create(IAirlyClient client)
                => new AirlyClientWrapper(client ?? throw new ArgumentException("IAirlyClient is null."));
        }

        #endregion
    }

    public enum ClientOperationType
    {
        GetNearbyInstallations
    }
}
