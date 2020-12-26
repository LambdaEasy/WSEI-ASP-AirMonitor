namespace AirMonitor.Domain.Installation
{
    public class Installation
    {
        public long? Id { get; set; }
        public long ExternalId { get; set; }
        public bool IsAirly { get; set; }
        public InstallationLocation Location { get; set; }
        public InstallationAddress Address { get; set; }
        public InstallationSponsor Sponsor { get; set; }
    }
}
