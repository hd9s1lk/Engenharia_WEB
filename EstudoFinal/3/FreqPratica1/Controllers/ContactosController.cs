using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreqPratica1.Models;

namespace FreqPratica1.Controllers
{
    public class ContactosController : Controller
    {
        private readonly DB_al78804 _context;

        public ContactosController(DB_al78804 context)
        {
            _context = context;
        }


        // GET: Contactos
        public async Task<IActionResult> Index()
        {
            var listagem = _context.Contacto.Count(A => A.Amigo);
            var listagemTOTAL = _context.Contacto.ToListAsync();

            if (listagem == 0)
            {
                return View(listagemTOTAL);
            }
            else
            {
                return View(listagem);
            }
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .FirstOrDefaultAsync(m => m.Email == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,NickName,Nome,Amigo")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Alterar(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.FindAsync(id);
            TempData["utilizador"] = contacto.NickName;
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(string id, [Bind("Email,NickName,Nome,Amigo")] Contacto contacto)
        {
            if (id != contacto.Email)
            {
                return NotFound();
            }


            var tamanho = contacto.NickName.Length;

            if(tamanho < 3)
            {
                ModelState.AddModelError("NickName", "O NickName deve ter pelo menos 3 caracteres.");
            }


           

                if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["utilizador"] = contacto.NickName;
                return RedirectToAction(nameof(Lista));
            }
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .FirstOrDefaultAsync(m => m.Email == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto != null)
            {
                _context.Contacto.Remove(contacto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(string id)
        {
            return _context.Contacto.Any(e => e.Email == id);
        }
    }
}
