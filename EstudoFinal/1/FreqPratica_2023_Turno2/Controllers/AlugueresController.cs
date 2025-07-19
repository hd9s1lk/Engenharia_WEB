using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreqPratica_2023_Turno2.Data;
using FreqPratica_2023_Turno2.Models;

namespace FreqPratica_2023_Turno2.Controllers
{
    public class AlugueresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlugueresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alugueres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alugueres.ToListAsync());
        }

        public async Task<IActionResult> Listar()
        {
            // Tenta obter o valor do cookie "filtro"
            var filtroCidade = Request.Cookies["filtro"];

            IQueryable<Alugueres> query = _context.Alugueres;

            if (!string.IsNullOrEmpty(filtroCidade))
            {
                // Filtra pela cidade se o cookie existir
                query = query.Where(a => a.Cidade == filtroCidade);
            }

            var lista = await query.ToListAsync();
            return View(lista);
        }
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alugueres = await _context.Alugueres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alugueres == null)
            {
                return NotFound();
            }

            return View(alugueres);
        }


        public IActionResult RemoverFiltro()
        {
            Response.Cookies.Delete("filtro");
            return RedirectToAction("Listar");
        }

        // GET: Alugueres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alugueres = await _context.Alugueres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alugueres == null)
            {
                return NotFound();
            }

            return View(alugueres);
        }

        public IActionResult Adiciona()
        {
            return View();
        }

        public IActionResult AplicarFiltro(string cidade)
        {
            if (!string.IsNullOrEmpty(cidade))
            {
                Response.Cookies.Append("filtro", cidade, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });
            }
            return RedirectToAction("Listar");
        }



        // POST: Alugueres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("Id,Apartamento,Cidade,Duracao,Mensalidade")] Alugueres alugueres)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                _context.Add(alugueres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(alugueres);
        }



        // GET: Alugueres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alugueres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apartamento,Cidade,Duracao,Mensalidade")] Alugueres alugueres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alugueres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alugueres);
        }

        // GET: Alugueres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alugueres = await _context.Alugueres.FindAsync(id);
            if (alugueres == null)
            {
                return NotFound();
            }
            return View(alugueres);
        }

        // POST: Alugueres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apartamento,Cidade,Duracao,Mensalidade")] Alugueres alugueres)
        {
            if (id != alugueres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alugueres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlugueresExists(alugueres.Id))
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
            return View(alugueres);
        }

        // GET: Alugueres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alugueres = await _context.Alugueres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alugueres == null)
            {
                return NotFound();
            }

            return View(alugueres);
        }

        // POST: Alugueres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alugueres = await _context.Alugueres.FindAsync(id);
            if (alugueres != null)
            {
                _context.Alugueres.Remove(alugueres);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlugueresExists(int id)
        {
            return _context.Alugueres.Any(e => e.Id == id);
        }
    }
}
