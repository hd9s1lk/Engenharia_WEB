using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using papp1.Data;
using papp1.Models;

namespace papp1.Controllers
{
    public class LojaController : Controller
    {
        private readonly papp1Context _context;

        public LojaController(papp1Context context)
        {
            _context = context;
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
            var listagem = _context.Carro.OrderByDescending(c => c.Ano);
            return View(listagem);
        }

        public async Task<IActionResult> Comprar(string marca)
        {
            if(marca == null)
            {
                return NotFound();
            }


            var carro = _context.Carro.FirstOrDefault(c => c.Marca == marca);
            
            if(carro == null)
            {
                return NotFound();
            }

            carro.Vendido = true;

            _context.Update(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Loja/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Marca == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Loja/Create
        public IActionResult Inserir()
        {
            return View();
        }

        // POST: Loja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir([Bind("Marca,Ano,Foto,Vendido")] Carro carro)
        {
            if (string.IsNullOrEmpty(carro.Marca))
            {
                ModelState.AddModelError("Marca", "A marca do carro é obrigatória.");
            }

            if(carro.Ano == null)
            {
                ModelState.AddModelError("Ano", "O ano do carro é obrigatório.");
            }

            if (string.IsNullOrEmpty(carro.Foto))
            {
                ModelState.AddModelError("Foto", "A foto do carro é obrigatória.");
            }

            if (carro.Ano < 2000 || carro.Ano > DateTime.UtcNow.Year)
            {
                ModelState.AddModelError("Ano", "O carro tem de estar entre o Ano 2000 e o ano atual");
            }

            if (!carro.Foto.Contains(".jpg"))
            {
                ModelState.AddModelError("Foto", "O ficheiro tem de ser jpg");
            }


            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Loja/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        // POST: Loja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Marca,Ano,Foto,Vendido")] Carro carro)
        {
            if (id != carro.Marca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Marca))
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
            return View(carro);
        }

        // GET: Loja/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Marca == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Loja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(string id)
        {
            return _context.Carro.Any(e => e.Marca == id);
        }
    }
}
