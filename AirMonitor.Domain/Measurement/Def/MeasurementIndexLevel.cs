namespace AirMonitor.Domain.Measurement
{
    public enum MeasurementIndexLevel
    {
        // CAQI
        VeryLow,
        Low,
        Medium,
        High,
        VeryHigh,

        // PIJP
        VeryGood,
        Good,
        Moderate,
        Satisfactory,
        Bad,
        VeryBad,

        // US_AQI i::(GOOD, MODERATE)
        UnhealthyForSensitiveGroups,
        Unhealthy,
        VeryUnhealthy,
        Hazardous,
        BeyondAqi,
        
        // AIRLY_CAQI i::(VERY_LOW, LOW, MEDIUM, HIGH, VERY_HIGH)
        Extreme,
        Airmageddon
    }
}
