using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()  //abrir view clicar no direito do rato no "Index" e adicionar view
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formData)    //cada view tem um controller, neste caso controller do index
        {
            ViewData["text_inserted"] = formData["name"]; //dados
            ViewData["other_Text_inserted"] = formData["age"];

            return View("Index2");
        }
    }
}
