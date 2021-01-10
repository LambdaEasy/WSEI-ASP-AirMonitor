using AirMonitor.Domain.Installation;
using InstallationDomain = AirMonitor.Domain.Installation.Installation;

namespace AirMonitor.Core.Installation.Command
{
    public readonly struct InstallationCreateCommand
    {
        #region Fields

        public long ExternalId => _externalId;

        private readonly long _externalId;
        private readonly bool _isAirly;
        private readonly InstallationCreateCommandLocation _location;
        private readonly InstallationCreateCommandAddress _address;
        private readonly InstallationCreateCommandSponsor _sponsor;

        #endregion

        #region Constructors

        private InstallationCreateCommand(long externalId,
                                         bool isAirly,
                                         InstallationCreateCommandLocation location,
                                         InstallationCreateCommandAddress address,
                                         InstallationCreateCommandSponsor sponsor)
        {
            _externalId = externalId;
            _isAirly = isAirly;
            _location = location;
            _address = address;
            _sponsor = sponsor;
        }

        #endregion

        public override string ToString()
            => "InstallationCreateCommand(" +
                   $"externalId={_externalId}, " +
                   $"isAirly={_isAirly}, " +
                   $"location={_location}," +
                   $"address={_address}," +
                   $"sponsor={_sponsor}" +
               ")";

        public InstallationDomain ToDomain()
            => InstallationDomain.Create(_externalId,
                                         _isAirly,
                                         _location.ToDomain(),
                                         _address.ToDomain(),
                                         _sponsor.ToDomain());

        #region StaticConstructors

        public static InstallationCreateCommand Create(long externalId,
                                                       bool isAirly,
                                                       InstallationCreateCommandLocation location,
                                                       InstallationCreateCommandAddress address,
                                                       InstallationCreateCommandSponsor sponsor)
            => new InstallationCreateCommand(externalId, isAirly, location, address, sponsor);

        #endregion

        #region Localization
        
        public readonly struct InstallationCreateCommandLocation
        {
            #region Fields

            private readonly float _latitude;
            private readonly float _longitude;
            private readonly float _elevation;

            #endregion

            public override string ToString()
                => $"InstallationCreateCommandLocation(latitude={_latitude}, longitude={_longitude}, elevation={_elevation})";

            public InstallationLocation ToDomain()
                => InstallationLocation.Create(_latitude, _longitude, _elevation);

            #region Construtors

            private InstallationCreateCommandLocation(float latitude, float longitude, float elevation)
            {
                _latitude = latitude;
                _longitude = longitude;
                _elevation = elevation;
            }

            #endregion

            #region StaticConstructors

            public static InstallationCreateCommandLocation Create(float latitude, float longitude, float elevation)
                // TODO validate
                => new InstallationCreateCommandLocation(latitude, longitude, elevation);

            #endregion
        }
        
        #endregion

        #region Address

        public readonly struct InstallationCreateCommandAddress
        {
            #region Fields

            private readonly string _country;
            private readonly string _city;
            private readonly string _street;
            private readonly string _number;
            private readonly string _displayAddress1;
            private readonly string _displayAddress2;

            #endregion

            #region Constructors

            private InstallationCreateCommandAddress(string country,
                                                     string city,
                                                     string street,
                                                     string number,
                                                     string displayAddress1,
                                                     string displayAddress2)
            {
                _country = country;
                _city = city;
                _street = street;
                _number = number;
                _displayAddress1 = displayAddress1;
                _displayAddress2 = displayAddress2;
            }

            #endregion

            public override string ToString()
                => "InstallationCreateCommandAddress(" +
                       $"country={_country}, " +
                       $"city={_city}, " +
                       $"street={_street}, " +
                       $"number={_number}, " +
                       $"displayAddress1={_displayAddress1}, " +
                       $"displayAddress2={_displayAddress2}" +
                   $")";

            public InstallationAddress ToDomain()
                => InstallationAddress.Create(_country, _city, _street, _number, _displayAddress1, _displayAddress2);

            #region StaticConstructors

            public static InstallationCreateCommandAddress Create(string country,
                                                                  string city,
                                                                  string street,
                                                                  string number,
                                                                  string displayAddress1,
                                                                  string displayAddress2)
                => new InstallationCreateCommandAddress(country, city, street, number, displayAddress1, displayAddress2);

            #endregion
        }
        
        #endregion

        #region Sponsor

        public readonly struct InstallationCreateCommandSponsor
        {
            #region Fields

            private readonly long _id;
            private readonly string _name;
            private readonly string _description;
            private readonly string _logoUri;
            private readonly string _linkUri;

            #endregion

            #region Constructors

            private InstallationCreateCommandSponsor(long id, string name, string description, string logoUri, string linkUri)
            {
                _id = id;
                _name = name;
                _description = description;
                _logoUri = logoUri;
                _linkUri = linkUri;
            }

            #endregion

            public override string ToString()
                => "InstallationCreateCommandSponsor(" +
                       $"name={_name}, " +
                       $"description={_description}, " +
                       $"logoUri={_logoUri}, " +
                       $"linkUri={_linkUri}" +
                   ")";
            
            public InstallationSponsor ToDomain()
                => InstallationSponsor.Create(_id, _name, _description, _logoUri, _linkUri);

            #region StaticConstructors

            public static InstallationCreateCommandSponsor Create(long id,
                                                                  string name,
                                                                  string description,
                                                                  string logoUri,
                                                                  string linkUri)
                => new InstallationCreateCommandSponsor(id, name, description, logoUri, linkUri);

            #endregion
        }

        #endregion
    }
}
