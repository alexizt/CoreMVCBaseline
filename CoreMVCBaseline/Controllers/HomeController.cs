using CoreMVCBaseline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CoreMVCBaseline.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
            _logger.LogInformation("Home Controller Instanciated");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
