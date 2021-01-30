using AirMonitor.Core.Installation;
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
            return View(_facade.GetAll());
        }
    }
}
