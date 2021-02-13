using System.Collections.Generic;
using System.Linq;
using AirMonitor.Client.Api.Response.Measurement;
using AirMonitor.Core.Measurement.Command;
using AirMonitor.Infrastructure.Client.Adapter.Mapping;
using ApiMeasurementValue = AirMonitor.Client.Api.Response.Measurement.Data.MeasurementValue;
using ApiMeasurementIndex = AirMonitor.Client.Api.Response.Measurement.Data.MeasurementIndex;
using ApiMeasurementStandard = AirMonitor.Client.Api.Response.Measurement.Data.MeasurementStandard;

namespace AirMonitor.Infrastructure.Client.Adapter.Measurement
{
    public static class AirlyClientToAirMonitorMeasurementAdapter
    {
        public static MeasurementCreateCommand FromApi(long installationExternalId, GetMeasurementByInstallationIdResponse api)
            => MeasurementCreateCommand.Create(installationExternalId,
                                               api.Current.FromDateTime,
                                               api.Current.TillDateTime,
                                               ValueAdapter.FromApi(api.Current.Values),
                                               IndexAdapter.FromApi(api.Current.Indexes),
                                               StandardAdapter.FromApi(api.Current.Standards));
        
        private static class ValueAdapter
        {
            internal static MeasurementCreateCommand.Value FromApi(ApiMeasurementValue api)
                => MeasurementCreateCommand.Value.Create(AirlyClientToAirMonitorEnumMapping.FromApi(api.Name), api.Value);

            internal static ISet<MeasurementCreateCommand.Value> FromApi(ISet<ApiMeasurementValue> api)
                => api.Select(FromApi).ToHashSet();
        }

        private static class IndexAdapter
        {
            internal static MeasurementCreateCommand.Index FromApi(ApiMeasurementIndex api)
                => MeasurementCreateCommand.Index.Create(AirlyClientToAirMonitorEnumMapping.FromApi(api.Name),
                                                         api.Value,
                                                         AirlyClientToAirMonitorEnumMapping.FromApi(api.Level),
                                                         api.Description,
                                                         api.Advice,
                                                         api.Color);

            internal static ISet<MeasurementCreateCommand.Index> FromApi(ISet<ApiMeasurementIndex> api)
                => api.Select(FromApi).ToHashSet();
        }
        
        private static class StandardAdapter
        {
            internal static MeasurementCreateCommand.Standard FromApi(ApiMeasurementStandard api)
                => MeasurementCreateCommand.Standard.Create(api.Name,
                                                            AirlyClientToAirMonitorEnumMapping.FromApi(api.Pollutant),
                                                            api.Limit,
                                                            api.Percent,
                                                            api.Averaging);

            internal static ISet<MeasurementCreateCommand.Standard> FromApi(ISet<ApiMeasurementStandard> api)
                => api.Select(FromApi).ToHashSet();
        }
    }
}
