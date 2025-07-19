using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_NOR22.Data;
using Final_NOR22.Models;

namespace Final_NOR22.Controllers
{
    public class HomeController : Controller
    {
        private readonly Final_NOR22Context _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(Final_NOR22Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var final_NOR22Context = await _context.Empresa.Include(x => x.Pais).OrderBy(x => x.Pais.Nome).ToListAsync();
            return View(final_NOR22Context);
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        public IActionResult Apagar(int id)
        {
            var empresa = _context.Empresa.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
                return NotFound();

            // Remover logotipo se existir
            if (!string.IsNullOrEmpty(empresa.Logotipo))
            {
                var logoPath = Path.Combine(_env.WebRootPath, "Logos", empresa.Logotipo);
                if (System.IO.File.Exists(logoPath))
                {
                    System.IO.File.Delete(logoPath);
                }
            }

            _context.Empresa.Remove(empresa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Create
        public IActionResult Registo()
        {
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo([Bind("Id,Nome,Logotipo,PaisID")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura", empresa.PaisID);
            return View(empresa);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura", empresa.PaisID);
            return View(empresa);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Logotipo,PaisID")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura", empresa.PaisID);
            return View(empresa);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Apagar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresa.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}
