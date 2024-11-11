using Microsoft.AspNetCore.Mvc;

namespace Aula_9.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Maintenance()
        {
            HttpContext.Response.StatusCode = 405;
            return View();
        }
    }
}
