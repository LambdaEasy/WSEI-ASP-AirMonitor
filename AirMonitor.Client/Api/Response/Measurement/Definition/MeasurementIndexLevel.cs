namespace AirMonitor.Client.Api.Response.Measurement.Definition
{
    public enum MeasurementIndexLevel
    {
        // CAQI
        VERY_LOW,
        LOW,
        MEDIUM,
        HIGH,
        VERY_HIGH,

        // PIJP
        VERY_GOOD,
        GOOD,
        MODERATE,
        SATISFACTORY,
        BAD,
        VERY_BAD,

        // US_AQI i::(GOOD, MODERATE)
        UNHEALTHY_FOR_SENSITIVE_GROUPS,
        UNHEALTHY,
        VERY_UNHEALTHY,
        HAZARDOUS,
        BEYOND_AQI,
        
        // AIRLY_CAQI i::(VERY_LOW, LOW, MEDIUM, HIGH, VERY_HIGH)
        EXTREME,
        AIRMAGEDDON
    }
}
