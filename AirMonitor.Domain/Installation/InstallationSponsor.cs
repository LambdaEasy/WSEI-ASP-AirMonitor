namespace AirMonitor.Domain.Installation
{
    public class InstallationSponsor
    {
        public long? InstallationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string LinkUri { get; set; }

        public InstallationSponsor(long? installationId,
                                   string name,
                                   string description,
                                   string logoUri,
                                   string linkUri)
        {
            InstallationId = installationId;
            Name = name;
            Description = description;
            LogoUri = logoUri;
            LinkUri = linkUri;
        }
        
        public static InstallationSponsor Create(string name,
                                                 string description,
                                                 string logoUri,
                                                 string linkUri)
            => new InstallationSponsor(null, name, description, logoUri, linkUri);
    }
}
