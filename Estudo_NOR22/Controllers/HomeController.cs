using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estudo_NOR22.Data;
using Estudo_NOR22.Models;

namespace Estudo_NOR22.Controllers
{
    public class HomeController : Controller
    {
        private readonly Estudo_NOR22Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(Estudo_NOR22Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var listagem = await _context.Empresa.Include(x => x.Pais).OrderBy(x => x.Pais.Nome).ToListAsync();
            return View(listagem);
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

        // GET: Home/Create
        public IActionResult Registo()
        {
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Nome");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo([Bind("Id,Nome,Logotipo")] EmpresaFotoViewModel empresa)
        {
            var PhotoExtensions = new[] { ".jpg" };

            var extension = Path.GetExtension(empresa.Logotipo.FileName).ToLower();

            if (!PhotoExtensions.Contains(extension))
            {
                ModelState.AddModelError("Logotipo", "submete um ficheiro valido");
            }



            if (ModelState.IsValid)
            {
                var newEmpresa = new Empresa();
                newEmpresa.Id = empresa.Id;
                newEmpresa.Nome = empresa.Nome;
                newEmpresa.Logotipo = Path.GetFileName(empresa.Logotipo.FileName);

                string coverFileName = Path.GetFileName(empresa.Logotipo.FileName);
                string coverFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Logotipo", coverFileName);

                using (var stream = new FileStream(coverFullPath, FileMode.Create))
                {
                    await empresa.Logotipo.CopyToAsync(stream);
                }


                    _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Nome", empresa.PaisID);
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
            ViewData["PaisID"] = new SelectList(_context.Set<Pais>(), "Id", "Nome", empresa.PaisID);
            return View(empresa);
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
