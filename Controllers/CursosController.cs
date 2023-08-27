using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;

namespace Escuela_Sor_Maria.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> ListaCursos()
        {
              return _context.tbCursos != null ? 
                          View(await _context.tbCursos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.tbCursos'  is null.");
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tbCursos == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.tbCursos
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (tbCursos == null)
            {
                return NotFound();
            }

            return View(tbCursos);
        }

        // GET: Cursos/Create
        public IActionResult RegistrarCursos()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarCursos([Bind("IdCurso,NombreCursoo,Descripcion,Nivel,Duracion,Estado")] tbCursos tbCursos)
        {
            if (ModelState.IsValid)
            {
                tbCursos.Estado = 1;
                _context.Add(tbCursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListaCursos));
            }
            return View(tbCursos);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> ActualizarCurso(int? id)
        {
            if (id == null || _context.tbCursos == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.tbCursos.FindAsync(id);
            if (tbCursos == null)
            {
                return NotFound();
            }
            return View(tbCursos);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarCurso(int id, [Bind("IdCurso,NombreCursoo,Descripcion,Nivel,Duracion,Estado")] tbCursos tbCursos)
        {
            if (id != tbCursos.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbCursosExists(tbCursos.IdCurso))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaCursos));
            }
            return View(tbCursos);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Desactivar(int? id)
        {
            if (id == null || _context.tbCursos == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.tbCursos
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (tbCursos == null)
            {
                return NotFound();
            }

            return View(tbCursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desactivar(int id)
        {
            if (_context.tbCursos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tbCursos'  is null.");
            }
            var tbCursos = await _context.tbCursos.FindAsync(id);
            if (tbCursos != null)
            {
                tbCursos.Estado = 2;
                _context.tbCursos.Update(tbCursos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListaCursos));
        }

        private bool tbCursosExists(int id)
        {
          return (_context.tbCursos?.Any(e => e.IdCurso == id)).GetValueOrDefault();
        }
    }
}
