namespace AirMonitor.Client.Api.Response.Installation
{
    public class GetInstallationsNearestResponse
    {
        #region Fields

        /// <summary>
        /// Unique installation identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Not described in api documentation
        /// </summary>
        public long? LocationId { get; set; }
        
        /// <summary>
        /// Altitude at which device is installed. Meters above mean sea level (mamsl).
        /// </summary>
        public double Elevation { get; set; }
        
        /// <summary>
        /// Flag indicating whether this installation is an Airly device or not (e.g. GIOŚ stations are flagged as false).
        /// </summary>
        public bool Airly { get; set; }
        
        /// <summary>
        /// Installation coordinates. Exact sensor location on map.
        /// </summary>
        public GetInstallationsNearestResponseLocation Location { get; set; }
        
        /// <summary>
        /// Address. All internal fields are optional.
        /// </summary>
        public GetInstallationsNearestResponseAddress Address { get; set; }
        
        /// <summary>
        /// Sponsor.
        /// </summary>
        public GetInstallationsNearestResponseSponsor Sponsor { get; set; }

        #endregion

        #region Constructors

        public GetInstallationsNearestResponse()
        {
            // serializer
        }

        public GetInstallationsNearestResponse(string id,
                                               long? locationId,
                                               double elevation,
                                               bool airly,
                                               GetInstallationsNearestResponseLocation location,
                                               GetInstallationsNearestResponseAddress address,
                                               GetInstallationsNearestResponseSponsor sponsor)
        {
            Id = id;
            LocationId = locationId;
            Elevation = elevation;
            Airly = airly;
            Location = location;
            Address = address;
            Sponsor = sponsor;
        }

        #endregion

        #region Location

        public class GetInstallationsNearestResponseLocation
        {
            #region Fields

            public double Latitude { get; set; }
            public double Longitude { get; set; }

            #endregion

            #region Constructors

            public GetInstallationsNearestResponseLocation()
            {
                // serializer
            }

            public GetInstallationsNearestResponseLocation(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            #endregion

        }

        #endregion

        #region Address

        public class GetInstallationsNearestResponseAddress
        {
            #region Fields
            
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
            public string DisplayAddress1 { get; set; }
            public string DisplayAddress2 { get; set; }
            

            #endregion

            #region Constructors

            public GetInstallationsNearestResponseAddress()
            {
                // serializer
            }

            public GetInstallationsNearestResponseAddress(string country,
                                                          string city,
                                                          string street,
                                                          string number,
                                                          string displayAddress1, 
                                                          string displayAddress2)
            {
                Country = country;
                City = city;
                Street = street;
                Number = number;
                DisplayAddress1 = displayAddress1;
                DisplayAddress2 = displayAddress2;
            }

            #endregion
        }

        #endregion

        #region Sponsor

        public class GetInstallationsNearestResponseSponsor
        {
            #region Fields

            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Logo { get; set; }
            public string Link { get; set; }
            public string DisplayName { get; set; }

            #endregion

            #region Constructors

            public GetInstallationsNearestResponseSponsor()
            {
                // serializer
            }

            public GetInstallationsNearestResponseSponsor(long id,
                                                          string name,
                                                          string description,
                                                          string logo,
                                                          string link,
                                                          string displayName)
            {
                Id = id;
                Name = name;
                Description = description;
                Logo = logo;
                Link = link;
                DisplayName = displayName;
            }

            #endregion
        }

        #endregion
    }
}