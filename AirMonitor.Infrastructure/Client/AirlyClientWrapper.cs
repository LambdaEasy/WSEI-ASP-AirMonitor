using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirMonitor.Client;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Core.Measurement;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Infrastructure.Client.Adapter.Installation;
using AirMonitor.Infrastructure.Client.Adapter.Measurement;
using AirMonitor.Util.Flow;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Infrastructure.Client
{
    public class AirlyClientWrapper : IInstallationClient, IMeasurementClient
    {
        private readonly ILogger<AirlyClientWrapper> _logger;

        private readonly IAirlyClient _airlyClient;

        public AirlyClientWrapper(ILogger<AirlyClientWrapper> logger, IAirlyClient airlyClient)
        {
            this._logger = logger ?? throw new ArgumentException("Logger is null.");
            this._airlyClient = airlyClient ?? throw new ArgumentException("IAirlyClient is null.");
        }

        public Either<InstallationError, IEnumerable<InstallationCreateCommand>> GetInstallationsNearby(InstallationGetAllNearbyCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
                ClientOperationType.GetNearbyInstallations,
                command,
                () => SynchronizeHttpCall // TODO move this to `TracedOperationClass` cos like that it kills a purpose of this class xD
                      (
                          _airlyClient.GetInstallationsNearest(AirMonitorToAirlyClientInstallationAdapter.FromCommand(command))
                      )
            )
            .Map(AirlyClientToAirMonitorInstallationAdapter.FromResponse)
            .MapLeft(AirlyClientToAirMonitorInstallationAdapter.ErrorFromResponse);
        }
        
        public Either<MeasurementError, MeasurementCreateCommand> GetMeasurementByInstallationId(MeasurementGetByInstallationExternalIdCommand command)
        {
            return TracedOperation.CallSync
            (
                _logger,
                ClientOperationType.GetMeasurementByInstallationId,
                command,
                () => SynchronizeHttpCall // TODO move this to `TracedOperationClass` cos like that it kills a purpose of this class xD
                      (
                          _airlyClient.GetMeasurementByInstallationId(AirMonitorToAirlyClientMeasurementAdapter.FromCommand(command))
                      )
            )
            .Map(AirlyClientToAirMonitorMeasurementAdapter.FromApi)
            .Peek(createCommand => createCommand.ExternalId = command.InstallationExternalId)
            .MapLeft(AirlyClientToAirMonitorMeasurementAdapter.ErrorFromResponse);
        }

        private static T SynchronizeHttpCall<T>(Task<T> httpCall)
            => httpCall.GetAwaiter().GetResult();
    }

    public enum ClientOperationType
    {
        GetNearbyInstallations,
        GetMeasurementByInstallationId
    }
}
