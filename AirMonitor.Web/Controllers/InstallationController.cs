using System.Collections.Generic;
using AirMonitor.Core;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Web.Models.Installation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirMonitor.Web.Controllers
{
    public class InstallationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IIntegrationFacade _integration;
        
        public InstallationController(ILogger<HomeController> logger,
                                      IIntegrationFacade integration)
        {
            this._logger = logger;
            this._integration = integration;
        }

        // TODO [refactor]
        [HttpGet]
        [Route("installation")]
        public IActionResult Installation(long? id, long? externalId)
        {
            if (id != null)
            {
                var viewModel = InstallationViewModel.OfResult("id", id.ToString(), _integration.GetById(id ?? 1));
                return View("Installation", viewModel);
            }

            if (externalId != null)
            {
                var viewModel = InstallationViewModel.OfResult("externalId", externalId.ToString(), _integration.GetByExternalId(externalId ?? 1));
                return View("Installation", viewModel);
            }
            return View("Index");
        }

        [HttpGet]
        [Route("installation/nearby")]
        public IActionResult Nearby(double latitude, double longitude) // TODO required queryParams
        {
            var installations = _integration.GetAllNearby(InstallationGetAllNearbyCommand.Create(latitude, longitude));
            return View(InstallationNearbyViewModel.Success(latitude, longitude, installations));
        }
    }
}
