namespace AirMonitor.Domain.Installation
{
    public class InstallationSponsor
    {
        public long? InstallationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string LinkUri { get; set; }
    }
}
