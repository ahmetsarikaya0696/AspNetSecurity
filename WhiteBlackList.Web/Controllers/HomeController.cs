using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhiteBlackList.Web.Filters;
using WhiteBlackList.Web.Models;

namespace WhiteBlackList.Web.Controllers
{
    //[ServiceFilter(typeof(CheckWhiteListFilter))] // Controller seviyesinde de kullanılabilir.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ServiceFilter(typeof(CheckWhiteListFilter))] // ctor belirtmeden kullanmak için Servislere eklemek gerekir.
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