using System.Collections.Generic;
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

        private readonly IInstallationFacade _facade;
        
        public InstallationController(ILogger<HomeController> logger,
                                      IInstallationFacade facade)
        {
            this._logger = logger;
            this._facade = facade;
        }

        public IActionResult Index()
        {
            return View(new HashSet<InstallationDto>());
        }

        [HttpGet]
        [Route("installation/nearby")]
        public IActionResult Index(float latitude, float longitude) // TODO required queryParams
        {
            return View(_facade.GetAllNearby(InstallationGetAllNearbyCommand.Create(latitude, longitude)));
        }
    }
}
