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
            if (User.Identity.IsAuthenticated)
            {
                var PorValidar = HttpContext.Session.GetString("PorValidar");
                PorValidar = _context.RegistoNota.Count(x => x.Username == "Anónimo").ToString();

                TempData["PorValidar"] = PorValidar;
            }
            return View(await _context.RegistoNota.ToListAsync());
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
            var existingId = _context.RegistoNota.FirstOrDefault(r => r.Id == registoNota.Id);
            var existingAluno = _context.RegistoNota.FirstOrDefault(r => r.NumAluno == registoNota.NumAluno);


            if (existingId != null)
            {
                ModelState.AddModelError("Id", "Já existe um registo com este ID.");
            }

            if(existingAluno != null)
            {
                ModelState.AddModelError("NumAluno", "Já existe um registo com este número de aluno.");
            }

            if (User.Identity.IsAuthenticated)
            {
                registoNota.Username = User.Identity.Name;
            } else
            {
                registoNota.Username = "Anónimo";
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
