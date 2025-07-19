using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_24.Models;

namespace NOR_24.Controllers
{
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class RegistosController : Controller
    {
        private readonly DB_al78804 _context;

        public RegistosController(DB_al78804 context)
        {
            _context = context;
        }

        // GET: Registos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistoUtilizador.ToListAsync());
        }

        public async Task<IActionResult> Lista()
        {
            var estado = HttpContext.Session.GetString("Estado");



            return View(await _context.RegistoUtilizador.ToListAsync());
        }

        public async Task<IActionResult> Valida(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);

            

            if (registoUtilizador == null)
            {
                return NotFound();
            }

            registoUtilizador.Valido = true;

            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));

            }
            return View(registoUtilizador);
        }

        public async Task<IActionResult> Invalida(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);



            if (registoUtilizador == null)
            {
                return NotFound();
            }

            registoUtilizador.Valido = false;

            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));

            }
            return View(registoUtilizador);
        }



        // GET: Registos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador
                .FirstOrDefaultAsync(m => m.RegistoId == id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }

            return View(registoUtilizador);
        }

        public IActionResult Adiciona()
        {
            ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
            return View();
        }

        // POST: Registos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if(registoUtilizador.Nome.Length > 200)
            {
                ModelState.AddModelError("Nome", "O nome não pode ter mais de 200 caracteres.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
                TempData["Sucesso"] = "Utilizador registado com sucesso";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
            return View(registoUtilizador);
        }


        // GET: Registos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }
            return View(registoUtilizador);
        }

        // POST: Registos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (id != registoUtilizador.RegistoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registoUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoUtilizadorExists(registoUtilizador.RegistoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registoUtilizador);
        }

        // GET: Registos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador
                .FirstOrDefaultAsync(m => m.RegistoId == id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }

            return View(registoUtilizador);
        }

        // POST: Registos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);
            if (registoUtilizador != null)
            {
                _context.RegistoUtilizador.Remove(registoUtilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoUtilizadorExists(int id)
        {
            return _context.RegistoUtilizador.Any(e => e.RegistoId == id);
        }
    }
}
