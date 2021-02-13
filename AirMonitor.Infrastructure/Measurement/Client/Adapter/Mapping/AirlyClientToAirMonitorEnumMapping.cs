using System.Collections.Generic;
using AirMonitor.Domain.Measurement;

using ApiMeasurementValueTypeName = AirMonitor.Client.Api.Response.Measurement.Definition.MeasurementValueTypeName;
using ApiMeasurementIndexName = AirMonitor.Client.Api.Response.Measurement.Definition.MeasurementIndexName;
using ApiMeasurementIndexLevel = AirMonitor.Client.Api.Response.Measurement.Definition.MeasurementIndexLevel;

namespace AirMonitor.Infrastructure.Measurement.Client.Adapter.Mapping
{
    public static class AirlyClientToAirMonitorEnumMapping
    {
        /*
         * TODO this might throw exception if value is not found
         *      although if it does it means that there is mistake in code,
         *      rather that handling eventual mistake, this should be checked at compilation time
         */
        public static MeasurementValueTypeName FromApi(ApiMeasurementValueTypeName api)
            => ValueTypeNameEnumMap[api];

        // TODO as above
        public static MeasurementIndexName FromApi(ApiMeasurementIndexName api)
            => IndexNameEnumMap[api];
        
        // TODO as above
        public static MeasurementIndexLevel FromApi(ApiMeasurementIndexLevel api)
            => IndexLevelEnumMap[api];

        #region ValueMap

        private static readonly IDictionary<ApiMeasurementValueTypeName, MeasurementValueTypeName> ValueTypeNameEnumMap = new Dictionary<ApiMeasurementValueTypeName, MeasurementValueTypeName>()
        {
            { ApiMeasurementValueTypeName.PM1,          MeasurementValueTypeName.PM1 },
            { ApiMeasurementValueTypeName.PM10,         MeasurementValueTypeName.PM10 },
            { ApiMeasurementValueTypeName.PM25,         MeasurementValueTypeName.PM25 },
            { ApiMeasurementValueTypeName.TEMPERATURE,  MeasurementValueTypeName.Temperature },
            { ApiMeasurementValueTypeName.HUMIDITY,     MeasurementValueTypeName.Humidity },
            { ApiMeasurementValueTypeName.PRESSURE,     MeasurementValueTypeName.Pressure },
            { ApiMeasurementValueTypeName.WIND_SPEED,   MeasurementValueTypeName.WindSpeed },
            { ApiMeasurementValueTypeName.WIND_BEARING, MeasurementValueTypeName.WindBearing },
            { ApiMeasurementValueTypeName.NO2,          MeasurementValueTypeName.NO2 },
            { ApiMeasurementValueTypeName.O3,           MeasurementValueTypeName.O3 },
            { ApiMeasurementValueTypeName.SO2,          MeasurementValueTypeName.SO2 },
            { ApiMeasurementValueTypeName.CO,           MeasurementValueTypeName.CO },
            { ApiMeasurementValueTypeName.H2S,          MeasurementValueTypeName.H2S },
            { ApiMeasurementValueTypeName.NO,           MeasurementValueTypeName.NO }
        };
        
        // TODO check lens of enums to throw on compilation

        #endregion

        #region IndexNameMap

        private static readonly IDictionary<ApiMeasurementIndexName, MeasurementIndexName> IndexNameEnumMap = new Dictionary<ApiMeasurementIndexName, MeasurementIndexName>()
        {
            { ApiMeasurementIndexName.CAQI,       MeasurementIndexName.Caqi},
            { ApiMeasurementIndexName.PIJP,       MeasurementIndexName.Pijp},
            { ApiMeasurementIndexName.US_AQI,     MeasurementIndexName.UsAqi},
            { ApiMeasurementIndexName.AIRLY_CAQI, MeasurementIndexName.AirlyCaqi}
        };
        
        // TODO check lens of enums to throw on compilation

        #endregion

        #region IndexLevelMap

        private static readonly IDictionary<ApiMeasurementIndexLevel, MeasurementIndexLevel> IndexLevelEnumMap = new Dictionary<ApiMeasurementIndexLevel, MeasurementIndexLevel>()
        {
            { ApiMeasurementIndexLevel.VERY_LOW,                       MeasurementIndexLevel.VeryLow },
            { ApiMeasurementIndexLevel.LOW,                            MeasurementIndexLevel.Low },
            { ApiMeasurementIndexLevel.MEDIUM,                         MeasurementIndexLevel.Medium },
            { ApiMeasurementIndexLevel.HIGH,                           MeasurementIndexLevel.High },
            { ApiMeasurementIndexLevel.VERY_HIGH,                      MeasurementIndexLevel.VeryHigh },
            { ApiMeasurementIndexLevel.VERY_GOOD,                      MeasurementIndexLevel.VeryGood },
            { ApiMeasurementIndexLevel.GOOD,                           MeasurementIndexLevel.Good },
            { ApiMeasurementIndexLevel.MODERATE,                       MeasurementIndexLevel.Moderate },
            { ApiMeasurementIndexLevel.SATISFACTORY,                   MeasurementIndexLevel.Satisfactory },
            { ApiMeasurementIndexLevel.BAD,                            MeasurementIndexLevel.Bad },
            { ApiMeasurementIndexLevel.VERY_BAD,                       MeasurementIndexLevel.VeryBad },
            { ApiMeasurementIndexLevel.UNHEALTHY_FOR_SENSITIVE_GROUPS, MeasurementIndexLevel.UnhealthyForSensitiveGroups },
            { ApiMeasurementIndexLevel.UNHEALTHY,                      MeasurementIndexLevel.Unhealthy },
            { ApiMeasurementIndexLevel.VERY_UNHEALTHY,                 MeasurementIndexLevel.VeryUnhealthy },
            { ApiMeasurementIndexLevel.HAZARDOUS,                      MeasurementIndexLevel.Hazardous },
            { ApiMeasurementIndexLevel.BEYOND_AQI,                     MeasurementIndexLevel.BeyondAqi },
            { ApiMeasurementIndexLevel.EXTREME,                        MeasurementIndexLevel.Extreme },
            { ApiMeasurementIndexLevel.AIRMAGEDDON,                    MeasurementIndexLevel.Airmageddon }
        };
        
        // TODO check lens of enums to throw on compilation

        #endregion
    }
}