using System;
using AirMonitor.Core.Installation;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Web.Models.Installation
{
    public class InstallationViewModel
    {
        private readonly InstallationDto _installation;
        private readonly InstallationError _error;
        
        public string SearchQueryName { get; set; }
        public string SearchQueryValue { get; set; }

        public InstallationDto Installation
            => _installation ?? throw new AggregateException("Attempted to access Success data on failure.");

        public InstallationError Error
            => _error ?? throw new AggregateException("Attempted to access Failure data on success.");

        private InstallationViewModel(string searchQueryName,
                                      string searchQueryValue,
                                      InstallationDto installation)
        {
            this.SearchQueryName = searchQueryName;
            this.SearchQueryValue = searchQueryValue;
            this._installation = installation;
        }
        
        private InstallationViewModel(string searchQueryName,
                                      string searchQueryValue,
                                      InstallationError error)
        {
            this.SearchQueryName = searchQueryName;
            this.SearchQueryValue = searchQueryValue;
            this._error = error;
        }

        public bool IsSuccess => _installation != null;

        public bool IsFailure => !IsSuccess;

        public static InstallationViewModel Success(string searchQueryName,
                                                    string searchQueryValue,
                                                    InstallationDto installation)
            => new InstallationViewModel(searchQueryName, searchQueryValue, installation);
        
        public static InstallationViewModel Failure(string searchQueryName,
                                                    string searchQueryValue,
                                                    InstallationError error)
            => new InstallationViewModel(searchQueryName, searchQueryValue, error);

        public static InstallationViewModel OfResult(string searchQueryName,
                                                     string searchQueryValue,
                                                     Either<InstallationError, InstallationDto> result)
            => result.IsLeft
             ? Failure(searchQueryName, searchQueryValue, result.GetLeft)
             : Success(searchQueryName, searchQueryValue, result.Get);
    }
}
