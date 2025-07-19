using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreqPratica2_23.Data;
using FreqPratica2_23.Models;

namespace FreqPratica2_23.Controllers
{
    public class BolsasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BolsasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bolsas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BolsaInvestigacao.ToListAsync());
        }

        public async Task<IActionResult> Lista()
        {
            var filtro = HttpContext.Session.GetString("filtro");
            IQueryable<BolsaInvestigacao> query = _context.BolsaInvestigacao;

            if (!string.IsNullOrEmpty(filtro))
            {
                query = query.Where(b => b.Area == filtro);
            }

            return View(await query.ToListAsync());
        }

        // GET: Bolsas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaInvestigacao = await _context.BolsaInvestigacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolsaInvestigacao == null)
            {
                return NotFound();
            }

            return View(bolsaInvestigacao);
        }


        public IActionResult AplicarFiltro(string area)
        {
            if (!string.IsNullOrEmpty(area))
            {
                HttpContext.Session.SetString("filtro", area);
            }
            return RedirectToAction(nameof(Lista));
        }

        public IActionResult RemoverFiltro()
        {
            HttpContext.Session.Remove("filtro");
            return RedirectToAction(nameof(Lista));
        }


        public IActionResult Adiciona()
        {
            return View();
        }

        // POST: Bolsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("Id,Titulo,Area,Mes,Renumeracao")] BolsaInvestigacao bolsaInvestigacao)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                _context.Add(bolsaInvestigacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(bolsaInvestigacao);
        }

        // GET: Bolsas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bolsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Area,Mes,Renumeracao")] BolsaInvestigacao bolsaInvestigacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolsaInvestigacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolsaInvestigacao);
        }

        // GET: Bolsas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaInvestigacao = await _context.BolsaInvestigacao.FindAsync(id);
            if (bolsaInvestigacao == null)
            {
                return NotFound();
            }
            return View(bolsaInvestigacao);
        }

        // POST: Bolsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Area,Mes,Renumeracao")] BolsaInvestigacao bolsaInvestigacao)
        {
            if (id != bolsaInvestigacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolsaInvestigacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolsaInvestigacaoExists(bolsaInvestigacao.Id))
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
            return View(bolsaInvestigacao);
        }

        // GET: Bolsas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaInvestigacao = await _context.BolsaInvestigacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolsaInvestigacao == null)
            {
                return NotFound();
            }

            return View(bolsaInvestigacao);
        }

        // POST: Bolsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolsaInvestigacao = await _context.BolsaInvestigacao.FindAsync(id);
            if (bolsaInvestigacao != null)
            {
                _context.BolsaInvestigacao.Remove(bolsaInvestigacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolsaInvestigacaoExists(int id)
        {
            return _context.BolsaInvestigacao.Any(e => e.Id == id);
        }
    }
}
