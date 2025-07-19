using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_22.Data;
using NOR_22.Models;

namespace NOR_22.Controllers
{
    public class HomeController : Controller
    {
        private readonly NOR_22Context _context;

        public HomeController(NOR_22Context context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var nOR_22Context = _context.Empresa.Include(e => e.Pais);
            return View(await nOR_22Context.ToListAsync());
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

        public IActionResult Registo()
        {
            ViewData["Paises"] = new SelectList(new[] { "Portugal", "Espanha", "França", "Alemanha" });
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
            var tamanho = empresa.Nome.Length;

            if (tamanho < 5)
            {
                ModelState.AddModelError("Nome", "O nome tem de ter no mínimo 5 caracteres");
            }


            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                ViewData["Paises"] = new SelectList(new[] { "Portugal", "Espanha", "França", "Alemanha" });
                return RedirectToAction(nameof(Index));
            }
            ViewData["Paises"] = new SelectList(new[] { "Portugal", "Espanha", "França", "Alemanha" });
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura", empresa.PaisID);
            return View(empresa);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Abreviatura");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Logotipo,PaisID")] Empresa empresa)
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
        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApagarConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresa.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        [Route("Empresas/{abreviaturaPais}")]
        public async Task<IActionResult> Empresas(string abreviaturaPais)
        {
            // Valida se a abreviatura existe na base de dados
            var pais = await _context.Set<Pais>().FirstOrDefaultAsync(p => p.Abreviatura == abreviaturaPais);
            if (pais == null)
            {
                return NotFound("Abreviatura de país inválida.");
            }

            // Busca empresas do país
            var empresas = await _context.Empresa
                .Include(e => e.Pais)
                .Where(e => e.Pais.Abreviatura == abreviaturaPais)
                .ToListAsync();

            return View("Index", empresas); // Reutiliza a view Index
        }
    }
}
