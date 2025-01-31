using Estudo_Exemplo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo_Exemplo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("test", "value", new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(10)
            });
            return View();
        }

        public IActionResult DeleteCookies()
        {
            foreach (var item in HttpContext.Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Delete(item);
            }

            return RedirectToAction(nameof(Index));
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
