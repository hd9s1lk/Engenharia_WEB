using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_24.Data;
using NOR_24.Models;

namespace NOR_24.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class RegistosController : Controller
    {
        private readonly NOR_24Context _context;

        public RegistosController(NOR_24Context context)
        {
            _context = context;
        }

        // GET: Registos
        public async Task<IActionResult> Index()
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


            var listagem = await _context.RegistoUtilizador.FindAsync(id);
            if (listagem == null)
            {
                return NotFound();
            }

            listagem.Valido = true;
            _context.Update(listagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Invalida(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }


            var listagem = await _context.RegistoUtilizador.FindAsync(id);
            if (listagem == null)
            {
                return NotFound();
            }

            listagem.Valido = true;
            _context.Update(listagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Registos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }

            return View(registoUtilizador);
        }

        // GET: Registos/Create
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
        public async Task<IActionResult> Adiciona([Bind("Id,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if(registoUtilizador.Nome.Length > 200)
            {
                ModelState.AddModelError("Nome", "O nome não pode ter mais de 200 caracteres.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
                TempData["Mensagem"] = "Utilizador registado com sucesso!";
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (id != registoUtilizador.Id)
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
                    if (!RegistoUtilizadorExists(registoUtilizador.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.RegistoUtilizador.Any(e => e.Id == id);
        }
    }
}
