using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_23.Data;
using NOR_23.Models;

namespace NOR_23.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly NOR_23Context _context;

        public VeiculoController(NOR_23Context context)
        {
            _context = context;
        }

        // GET: Veiculo
        public async Task<IActionResult> Index()
        {
            var nOR_23Context = _context.Veiculo.Include(v => v.Proprietario);
            return View(await nOR_23Context.ToListAsync());
        }

        // GET: Veiculo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .Include(v => v.Proprietario)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculo/Create
        public IActionResult Adicionar()
        {
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nacionalidade");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("Matricula,Marca,Modelo,ProprietarioId")] Veiculo veiculo)
        {
            var MatriculaExistente = await _context.Veiculo.AnyAsync(v => v.Matricula == veiculo.Matricula);

            if (MatriculaExistente)
            {
                ModelState.AddModelError("Matricula", "Matrícula já existente");
            }

            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Views_Proprietarios_Detalhes));
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nacionalidade", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nacionalidade", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Matricula,Marca,Modelo,ProprietarioId")] Veiculo veiculo)
        {
            if (id != veiculo.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Matricula))
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
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nacionalidade", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .Include(v => v.Proprietario)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculo.Remove(veiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(string id)
        {
            return _context.Veiculo.Any(e => e.Matricula == id);
        }
    }
}
