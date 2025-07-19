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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LojaController(PAPP1Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
            var listagem = _context.Carro.OrderBy(c => c.Ano);
            return View(await _context.Carro.ToListAsync());
        }

        public async Task<IActionResult> Comprar(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FirstOrDefaultAsync(m => m.Marca == id);

            if (carro == null)
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
            var PhotoExtensions = new[] { ".jpg", ".jpeg"};

            var extension = Path.GetExtension(carro.Foto).ToLower();

            if (!PhotoExtensions.Contains(extension))
            {
                ModelState.AddModelError("Foto", "A foto deve ser um arquivo .jpg ou .jpeg.");
            }

            string filename = Path.GetFileName(carro.Foto);
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "Fotos", filename);


                if (carro.Ano < 2000 || carro.Ano > DateTime.Now.Year)
                {
                    ModelState.AddModelError("Ano", "O ano deve ser entre 2000 e o ano atual.");
                }

            if (string.IsNullOrEmpty(carro.Marca))
            {
                ModelState.AddModelError("Foto", "A foto é obrigatória.");
            }


            if (ModelState.IsValid)
            {
                carro.Foto = Path.GetFileName(carro.Foto);

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
