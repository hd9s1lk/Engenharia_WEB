using Estudo_Aula10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo_Aula10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string TestAjaxForm(string Text)
        {
            return "<br> Receive " + Text + "at strong" + DateTime.Now + "</strong>";
        }

        public IActionResult Index()
        {
            return View();
        }

        public string TestAjaxLink()
        {
            System.Threading.Thread.Sleep(5000);
            return "executed at <strong>" + DateTime.Now + "</strong>";
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
