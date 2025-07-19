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
            var estado = HttpContext.Session.GetString("estado");

            if (string.IsNullOrEmpty(estado) || estado == "editar")
            {
                return View(await _context.RegistoUtilizador.ToListAsync());
            }

            return View(await _context.RegistoUtilizador.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Valida(int id)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invalida(int id)
        {
            var listagem = await _context.RegistoUtilizador.FindAsync(id);

            if (listagem == null)
            {
                return NotFound();
            }
            
            listagem.Valido = false;
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
            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
                TempData["Mensagem"] = "Registo adicionado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Regime"] = new SelectList(new[] { "Ordinario", "Especial", "Super" });
            return View(registoUtilizador);
        }

        // GET: Registos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
