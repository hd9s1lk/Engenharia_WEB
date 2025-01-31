using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estudo_Exemplo1.Data;
using Estudo_Exemplo1.Models;
using Estudo_Exemplo1.Migrations;

namespace Estudo_Exemplo1.Controllers
{

    [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)]
    public class CarrosController : Controller
    {
        private readonly Estudo_Exemplo1Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarrosController(Estudo_Exemplo1Context context, IWebHostEnvironment environment)
        {
            _context = context;
            _webHostEnvironment = environment;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var listagem = await _context.Carro.Include(x => x.Pessoas).ToListAsync();
            return View(listagem);
        }

        public async Task<IActionResult> OrdAlfa()
        {
            var ord = await _context.Carro.OrderBy(x => x.Marca).ToListAsync();
            return View(ord);
        }

        public async Task<IActionResult> OrdAlfa2()
        {
            var ord2 = await _context.Carro.OrderByDescending(x => x.Marca).ToListAsync();
            return View(ord2);
        }

        public IActionResult OrdAlfa3()
        {
            var ord3 = _context.Carro.Include(c => c.Pessoas);
            return View(ord3);
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Fotografia")] CarroFotoViewModel carroFotoViewModel)
        {
            var PhotoExtensions = new[] { ".jpg" };

            var extension = Path.GetExtension(carroFotoViewModel.Fotografia.FileName).ToLower();

            if (!PhotoExtensions.Contains(extension))
            {
                ModelState.AddModelError("Fotografia", "Tem de ser jpg");
            }

            if (id != carroFotoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var newCarro = new Carro();
                    newCarro.Marca = carroFotoViewModel.Marca;
                    newCarro.Fotografia = Path.GetFileName(carroFotoViewModel.Fotografia.FileName);


                    string CoverFileName = Path.GetFileName(carroFotoViewModel.Fotografia.FileName);
                    string coverFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "FotoCarro", CoverFileName);

                    using (var stream = new FileStream(coverFullPath, FileMode.Create))
                    {
                        await carroFotoViewModel.Fotografia.CopyToAsync(stream);
                    }


                    _context.Update(carroFotoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carroFotoViewModel.Id))
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
            return View(carroFotoViewModel);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}
