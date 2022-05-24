using CoreMVCBaseline.Models;
using CoreMVCBaseline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CoreMVCBaseline.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

        private readonly IProtectedCookies _protectedCookies;

        public HomeController(ILogger<HomeController> logger, IProtectedCookies protectedCookies) 
            : base(logger)
        {
            _logger.LogInformation("Home Controller Instanciated");
            _protectedCookies = protectedCookies;
        }

        public IActionResult Index()
        {
            _protectedCookies.Set("MYCookie1", "MyCookieValue");
            return View();
        }

        public IActionResult Privacy()
        {
            var cookieCValue = _protectedCookies.Get("MYCookie1");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
