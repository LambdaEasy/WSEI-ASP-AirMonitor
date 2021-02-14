using System;
using AirMonitor.Core.Installation;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Domain.Measurement.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Web.Models.Installation
{
    public class InstallationViewModel
    {
        private readonly InstallationDto _installation;
        private readonly InstallationError _error;

        public InstallationDto Installation
            => _installation ?? throw new AggregateException("Attempted to access Success data on failure.");

        public InstallationError Error
            => _error ?? throw new AggregateException("Attempted to access Failure data on success.");

        public string Title
            => $"Installation ({Installation.ExternalId};{Installation.Id})";
        
        public string Location
            => $"Located at ({Installation.Location.Latitude}, {Installation.Location.Longitude})";
        
        public string Address
            => $"Near address {Installation.Address.DisplayAddress1}, {Installation.Address.DisplayAddress2}";

        public string Sponsor
            => $"Founded by {Installation.Sponsor.Name}";

        public MeasurementDto Measurement => Installation.Measurement;

        private InstallationViewModel(InstallationDto installation)
        {
            this._installation = installation;
        }
        
        private InstallationViewModel(InstallationError error)
        {
            this._error = error;
        }

        public bool IsSuccess => _installation != null;

        public bool IsFailure => !IsSuccess;

        public static InstallationViewModel Success(InstallationDto installation)
            => new InstallationViewModel(installation);
        
        public static InstallationViewModel Failure(InstallationError error)
            => new InstallationViewModel(error);

        public static InstallationViewModel OfResult(Either<InstallationError, InstallationDto> result)
            => result.IsLeft
             ? Failure(result.GetLeft)
             : Success(result.Get);
    }
}
