using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estudo_Aula7.Data;
using Estudo_Aula7.Models;

namespace Estudo_Aula7.Controllers
{
    public class UsersController : Controller
    {
        private readonly Estudo_Aula7Context _context;

        public UsersController(Estudo_Aula7Context context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                User u = _context.User.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (u == null)
                {
                    ModelState.AddModelError("username", "username errado");
                } else
                {
                    HttpContext.Session.SetString("user", username);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".Estudo_Aula7.Session");
            return RedirectToAction("Index","Home");
        }

        public IActionResult Preferences()
        {
            ViewBag.mode = HttpContext.Request.Cookies["viewMode"] ?? "light";

            return View();
        }

        [HttpPost]
        public IActionResult Preferences(string mode)
        {
            HttpContext.Response.Cookies.Append("viewMode", mode, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
            return RedirectToAction("Index", "Home");
        }
    }

}
