namespace AirMonitor.Client
{
    public interface IAirlyClientConfig
    {
        bool IsSecure { get; }
        string HostAddress { get; }
        string HostPort { get; }
        string ApiPrefix { get; }
        string ApiVersion { get; }
        string ApiAuthKey { get; }
        string ApiAuthValue { get; }
    }
}
