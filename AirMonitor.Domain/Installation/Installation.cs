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

        public Installation(long? id,
                            long externalId,
                            bool isAirly,
                            InstallationLocation location,
                            InstallationAddress address,
                            InstallationSponsor sponsor)
        {
            Id = id;
            ExternalId = externalId;
            IsAirly = isAirly;
            Location = location;
            Address = address;
            Sponsor = sponsor;
        }

        public static Installation Create(long externalId,
                                          bool isAirly,
                                          InstallationLocation location,
                                          InstallationAddress address,
                                          InstallationSponsor sponsor)
            => new Installation(null, externalId, isAirly, location, address, sponsor);
    }
}
