using System.Collections.Generic;
using AirMonitor.Core;
using AirMonitor.Core.Installation;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
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

        public IActionResult Index()
        {
            return View(new HashSet<InstallationDto>());
        }

        [HttpGet]
        [Route("installation/nearby")]
        public IActionResult Index(double latitude, double longitude) // TODO required queryParams
        {
            return View(_integration.GetAllNearby(InstallationGetAllNearbyCommand.Create(latitude, longitude)));
        }
    }
}
