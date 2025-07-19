using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enunciado.Models;

namespace Enunciado.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly DB_al78804 _context;

        public EstudantesController(DB_al78804 context)
        {
            _context = context;
        }

        // GET: Estudantes
        public async Task<IActionResult> Listar()
        {
            var DataAtual = DateTime.Now.Year;

            var ano = _context.Aluno.Select(a => a.Data_Nascimento.Year).ToString();

            var ano2 = Convert.ToInt32(ano);

            var Final = DataAtual - ano2;

            TempData["ano"] = Final;


            var listagem = _context.Aluno.OrderBy(a => a.Data_Nascimento).ToListAsync();
            return View(listagem);
        }

        // GET: Estudantes/Details/5
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

        // GET: Estudantes/Create
        public IActionResult Registo()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo([Bind("Numero,Email,Nome,Data_Nascimento")] Aluno aluno)
        {
            if(aluno.Email == null || aluno.Numero == null || aluno.Nome == null && aluno.Data_Nascimento == null)
            {
                ModelState.AddModelError("", "Todos os campos são obrigatórios.");
            }

            if (_context.Aluno.Any(a => a.Numero == aluno.Numero))
            {
                ModelState.AddModelError("Numero", "Número já existe. Escolha outro");
            }

            if(_context.Aluno.Any(a => a.Email == aluno.Email))
            {
                ModelState.AddModelError("Email", "Email já existe. Escolha outro");
            }




            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(aluno);
        }

        // GET: Estudantes/Edit/5
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

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,Email,Nome,Data_Nascimento")] Aluno aluno)
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

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Remover(int? id)
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

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno != null)
            {
                _context.Aluno.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Numero == id);
        }
    }
}
