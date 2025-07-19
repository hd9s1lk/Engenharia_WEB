using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAPP1.Data;
using PAPP1.Models;

namespace PAPP1.Controllers
{
    public class LojaController : Controller
    {
        private readonly PAPP1Context _context;

        public LojaController(PAPP1Context context)
        {
            _context = context;
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
            var listagem = await _context.Carro.OrderByDescending(c => c.Ano).ToListAsync();
            return View(listagem);
        }


        public async Task<IActionResult> Comprar(string id)
        {
            var listagem = _context.Carro.FirstOrDefault(m => m.Marca == id);

            if(listagem == null)
            {
                return NotFound();
            }

            listagem.Vendido = true;
            _context.Update(listagem);
            await _context.SaveChangesAsync();
            return View(nameof(Index));

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
            var ano = _context.Carro
                .Where(c => c.Marca == carro.Marca)
                .Select(c => c.Ano)
                .FirstOrDefault();

            if(ano < 2000 || ano > DateTime.Now.Year)
            {
                ModelState.AddModelError("Ano", "O ano deve ser entre 2000 e o ano atual.");
            }

            var foto = _context.Carro
                .Where(c => c.Marca == carro.Marca)
                .Select(c => c.Foto)
                .FirstOrDefault();

            if(!foto.EndsWith(".jpg"))
            {
                ModelState.AddModelError("Foto", "A foto deve ter a extensão .jpg.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Loja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Ano,Foto,Vendido")] Carro carro)
        {
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
