using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_23.Data;
using NOR_23.Models;

namespace NOR_23.Controllers
{
    public class ProprietariosController : Controller
    {
        private readonly NOR_23Context _context;

        public ProprietariosController(NOR_23Context context)
        {
            _context = context;
        }

        // GET: Proprietarios
        public async Task<IActionResult> Index()
        {
            var listagem = _context.Proprietario.Select(x => new ProprietarioVeiculoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Nacionalidade = x.Nacionalidade,
                NumVeiculos = x.Veiculos != null ? x.Veiculos.Count : 0
            });
            return View(listagem);
        }

        // GET: Proprietarios/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario
                .FirstOrDefaultAsync(m => m.Id == id);

            TempData["Proprietario"] = proprietario.Nome;
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }

        // GET: Proprietarios/Create
        public IActionResult Create()
        {
            return View();
        }



        public async Task<IActionResult> ordena()
        {
            var ordem = HttpContext.Session.GetString("ordem");

            if (ordem == null || ordem == "decrescente")
            {
                var listagem = _context.Proprietario.Select(x => new ProprietarioVeiculoViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Nacionalidade = x.Nacionalidade,
                    NumVeiculos = x.Veiculos != null ? x.Veiculos.Count : 0
                }).OrderBy(x => x.Nome);
                HttpContext.Session.SetString("ordem", "crescente");
                return PartialView("Listagem", listagem);
            }
            else if (ordem == "crescente")
            {
                var listagem = _context.Proprietario.Select(x => new ProprietarioVeiculoViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Nacionalidade = x.Nacionalidade,
                    NumVeiculos = x.Veiculos != null ? x.Veiculos.Count : 0
                }).OrderByDescending(x => x.Nome);
                HttpContext.Session.SetString("ordem", "decrescente");
                return PartialView("Listagem", listagem);
            }
            else
            {
                return NotFound();

            }
        }


        // POST: Proprietarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nacionalidade")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proprietario);
        }

        // GET: Proprietarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario.FindAsync(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);
        }

        // POST: Proprietarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nacionalidade")] Proprietario proprietario)
        {
            if (id != proprietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietarioExists(proprietario.Id))
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
            return View(proprietario);
        }

        // GET: Proprietarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }

        // POST: Proprietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proprietario = await _context.Proprietario.FindAsync(id);
            if (proprietario != null)
            {
                _context.Proprietario.Remove(proprietario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietarioExists(int id)
        {
            return _context.Proprietario.Any(e => e.Id == id);
        }
    }
}
