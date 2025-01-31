using Estudo_Aula7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo_Aula7.Controllers
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
            return View();
        }

        public IActionResult AddCookies()
        {
            HttpContext.Response.Cookies.Append("Test1", "Value1");
            HttpContext.Response.Cookies.Append("Test2", "Value2", new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(10),
            });

            HttpContext.Response.Cookies.Append("Test3", "Value3",
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1)
                });


            return RedirectToAction("Index");
        }

        public IActionResult DeleteCookies()
        {
            foreach(var item in HttpContext.Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Delete(item);
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddSessionVariables()
        {
            HttpContext.Session.SetString("String value", "Text value here");
            HttpContext.Session.SetInt32("IntegerValue", 100);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSessionVariables()
        {
            foreach(var item in HttpContext.Session.Keys)
            {
                HttpContext.Session.Remove(item);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSession()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Index");
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
