using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REC_24.Data;
using REC_24.Models;

namespace REC_24.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gestao
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistoNota.ToListAsync());
        }

        public async Task<IActionResult> Notas()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var sessao = HttpContext.Session.GetString("PorValidar");
            //    var PorValidar = _context.RegistoNota.Where(x => x.Username == "Anónimo").Count();

            //    TempData["Anonimos"] = PorValidar;
            //}
            var sessao = HttpContext.Session.GetString("PorValidar");
            var PorValidar = _context.RegistoNota.Where(x => x.Username == "Anónimo").Count();

            TempData["Anonimos"] = PorValidar;

            return View(await _context.RegistoNota.ToListAsync());
        }

        public async Task<IActionResult> Validar(int? id)
        {
            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota == null)
            {
                return NotFound();
            }

            registoNota.Username = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Update(registoNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Notas));
            }
            return View(registoNota);
        }


        // GET: Gestao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return NotFound();
            }

            return View(registoNota);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        // POST: Gestao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir([Bind("Id,NumAluno,Nota,Username")] RegistoNota registoNota)
        {
            if(!registoNota.NumAluno.Equals(null))
            {
                ModelState.AddModelError("NumAluno", "O número já existe. Insira outro");
            }

            if(registoNota.Nota < 0 || registoNota.Nota > 20)
            {
                ModelState.AddModelError("Nota", "A nota deve estar entre 0 e 20.");
            }

            if (!User.Identity.IsAuthenticated)
            {
                registoNota.Username.Equals("Anónimo");
            } else
            {
                registoNota.Username = User.Identity.Name;
            }


            if (ModelState.IsValid)
            {
                _context.Add(registoNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Notas));
            }
            return View(registoNota);
        }

        // GET: Gestao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumAluno,Nota,Username")] RegistoNota registoNota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registoNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registoNota);
        }

        // GET: Gestao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota == null)
            {
                return NotFound();
            }
            return View(registoNota);
        }

        // POST: Gestao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumAluno,Nota,Username")] RegistoNota registoNota)
        {
            if (id != registoNota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registoNota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoNotaExists(registoNota.Id))
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
            return View(registoNota);
        }

        public async Task<IActionResult> Remover(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return NotFound();
            }

            return View(registoNota);
        }

        // POST: Gestao/Delete/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverConfirmed(int id)
        {
            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota != null)
            {
                _context.RegistoNota.Remove(registoNota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Notas));
        }

        // GET: Gestao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return NotFound();
            }

            return View(registoNota);
        }

        // POST: Gestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota != null)
            {
                _context.RegistoNota.Remove(registoNota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoNotaExists(int id)
        {
            return _context.RegistoNota.Any(e => e.Id == id);
        }
    }
}
