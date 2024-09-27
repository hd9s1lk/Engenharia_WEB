using Aula2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class PersonController : Controller   //
    {
        // GET: PersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person newPerson)
        {
            if (ModelState.IsValid)
            {
                TempData["values"] = newPerson.Name + " [ " + newPerson.Age + " ]";
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return View();
            }
        }
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(collection["name"]))
        //        {
        //            ModelState.AddModelError("name", "Mandatory field");
        //        }

        //        if (string.IsNullOrEmpty(collection["age"]))
        //        {
        //            ModelState.AddModelError("age", "Mandatory field");
        //        }
        //    else
        //    {
        //        int aux;
        //        try
        //        {
        //            aux = int.Parse(collection["age"]);
        //            if(aux<18 || aux > 100)
        //                {
        //                    ModelState.AddModelError("age", "Age should be between 18 and 100");
        //                }
        //        }

        //            catch(FormatException)
        //            {
        //                ModelState.AddModelError("age", "Must indicate a integer number");
        //            }
        //    }

        //        if (ModelState.IsValid)
        //        {
        //            TempData["values"] = collection["name"] + " [ " + collection["age"] + " ] ";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return View();
        //        }

        //    }

        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
