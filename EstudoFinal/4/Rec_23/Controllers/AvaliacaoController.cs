using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rec_23.Data;
using Rec_23.Models;

namespace Rec_23.Controllers
{

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class AvaliacaoController : Controller
    {
        private readonly Rec_23Context _context;

        public AvaliacaoController(Rec_23Context context)
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
            var protegido = HttpContext.Session.GetString("protegido");

            if(protegido == null || protegido == "true")
            {
                var total = _context.Aluno.Count();
                var positivas = _context.Aluno.Count(a => a.Nota >= 9.5);
                var negativas = _context.Aluno.Count(a => a.Nota < 9.5);

                TempData["TOTAL"] = total;
                TempData["POSITIVAS"] = positivas;
                TempData["NEGATIVAS"] = negativas;
            }


            var listagem = _context.Aluno.OrderBy(a => a.Nome).ToListAsync();
            return View(listagem);
        }

        // GET: Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Avaliacao/Create
        public IActionResult Adicionar()
        {
            TempData["Mensagem"] = "Aluno adicionado com sucesso";
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("Numero,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            var numeroExistente = _context.Aluno.Any(a => a.Numero == aluno.Numero);

            if(numeroExistente != false)
            {
                ModelState.AddModelError("Numero", "Número já existente");
            }

            if(aluno.Nome == null)
            {
                ModelState.AddModelError("Nome", "Nome é obrigatório");
            }


            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Aluno adicionado com sucesso!";
                return RedirectToAction(nameof(Adicionar));
            }
            return View(aluno);
        }

        // GET: Avaliacao/Edit/5
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
        public async Task<IActionResult> Alterar(int id, [Bind("Numero,Nome,Pratica,Teorica,Nota,Data")] Aluno aluno)
        {
            if (id != aluno.Numero)
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
                    if (!AlunoExists(aluno.Numero))
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
                .FirstOrDefaultAsync(m => m.Numero == id);
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
            return _context.Aluno.Any(e => e.Numero == id);
        }
    }
}
