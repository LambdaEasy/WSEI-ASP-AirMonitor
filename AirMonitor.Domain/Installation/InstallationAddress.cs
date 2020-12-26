namespace AirMonitor.Domain.Installation
{
    public class InstallationAddress
    {
        public long? InstallationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DisplayAddress1 { get; set; }
        public string DisplayAddress2 { get; set; }

        public InstallationAddress(long? installationId,
                                   string country,
                                   string city,
                                   string street,
                                   string number,
                                   string displayAddress1,
                                   string displayAddress2)
        {
            InstallationId = installationId;
            Country = country;
            City = city;
            Street = street;
            Number = number;
            DisplayAddress1 = displayAddress1;
            DisplayAddress2 = displayAddress2;
        }

        public static InstallationAddress Create(string country,
                                                 string city,
                                                 string street,
                                                 string number,
                                                 string displayAddress1,
                                                 string displayAddress2)
            => new InstallationAddress(null, country, city, street, number, displayAddress1, displayAddress2);
    }
}
