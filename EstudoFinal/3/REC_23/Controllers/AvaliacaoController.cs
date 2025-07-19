using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REC_23.Data;
using REC_23.Models;

namespace REC_23.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class AvaliacaoController : Controller
    {
        private readonly REC_23Context _context;

        public AvaliacaoController(REC_23Context context)
        {
            _context = context;
        }

        // GET: Avaliacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluno.ToListAsync());
        }

        public async Task<IActionResult> Pauta()
        {
            var Protegido = HttpContext.Session.GetString("protegido");

            if(Protegido == null || Protegido == "true")
            {
                var total = await _context.Aluno.CountAsync();
                var Positivas = await _context.Aluno.CountAsync(a => a.Nota >= 9.5);
                var Negativas = await _context.Aluno.CountAsync(a => a.Nota < 9.5);

                TempData["Total"] = total;
                TempData["Positivas"] = Positivas;
                TempData["Negativas"] = Negativas;
            }


            var listagem = _context.Aluno.OrderBy(x => x.Nome).ToListAsync();
            return View(Pauta);
        }

        // GET: Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        public IActionResult Adicionar()
        {
            TempData["Sucesso"] = "Aluno adicionado com sucesso!";
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("Id,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            var alunoExistente = _context.Aluno.FirstOrDefault(a => a.Id == aluno.Id);

            if (alunoExistente != null)
            {
                ModelState.AddModelError(string.Empty, "Já existe um aluno com este ID. Por favor, use um ID diferente.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                TempData["Sucesso"] = "Aluno adicionado com sucesso!";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Adicionar));
            }
            return View(aluno);
        }


        // GET: Avaliacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            return View(aluno);
        }

        // GET: Avaliacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            return View(aluno);
        }

        // GET: Avaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno != null)
            {
                _context.Aluno.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}
