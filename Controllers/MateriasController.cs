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
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CargarConbo()
        {
            var profesoresConNombreCompleto = _context.tbPersona
                 .Select(p => new SelectListItem
                 {
                     Value = p.Cedula,
                     Text = $"{p.Nombre} {p.Apellido1} {p.Apellido2}"
                 })
             .ToList();

            ViewData["CursoID"] = new SelectList(_context.tbCursos, "IdCurso", "NombreCursoo");
            ViewData["ProfesorAsignado"] = new SelectList(profesoresConNombreCompleto, "Value", "Text");
        }



        // GET: Materias
        public async Task<IActionResult> ListaMaterias()
        {
            var materiasConInfo = await _context.tbMaterias
        .Include(t => t.Curso)
        .Include(t => t.Profesor)
        .Select(m => new ViewModel
        {
            Materia = m,
            Curso = m.Curso,
            Profesor = m.Profesor,
            NombreCompletoProfesor = $"{m.Profesor.Nombre} {m.Profesor.Apellido1} {m.Profesor.Apellido2}"
        })
        .ToListAsync();

            return View(materiasConInfo);
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tbMaterias == null)
            {
                return NotFound();
            }

            var tbMaterias = await _context.tbMaterias
                .Include(t => t.Curso)
                .Include(t => t.Profesor)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (tbMaterias == null)
            {
                return NotFound();
            }

            return View(tbMaterias);
        }

        // GET: Materias/Create
        public IActionResult RegistrarMateria()
        {
            CargarConbo();

            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarMateria( tbMaterias tbMaterias)
        {

            if (!ModelState.IsValid)
            {
                tbMaterias.Estado = 1;
                _context.Add(tbMaterias);
                await _context.SaveChangesAsync();


                CargarConbo();
                return RedirectToAction(nameof(ListaMaterias));
            }


            CargarConbo();
            return View(tbMaterias);
        }

       
        // GET: Materias/Edit/5
        public async Task<IActionResult> ActualizarMateria(int? id)
        {
            if (id == null || _context.tbMaterias == null)
            {
                return NotFound();
            }

            var tbMaterias = await _context.tbMaterias.FindAsync(id);
            if (tbMaterias == null)
            {
                return NotFound();
            }
            CargarConbo();
            return View(tbMaterias);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarMateria(int id,  tbMaterias tbMaterias)
        {
            if (id != tbMaterias.IdMateria)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMaterias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbMateriasExists(tbMaterias.IdMateria))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaMaterias));
            }
            CargarConbo();
            return View(tbMaterias);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> SuspenderMateria(int? id)
        {
            if (id == null || _context.tbMaterias == null)
            {
                return NotFound();
            }

            var tbMaterias = await _context.tbMaterias
                .Include(t => t.Curso)
                .Include(t => t.Profesor)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (tbMaterias == null)
            {
                return NotFound();
            }

            return View(tbMaterias);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuspenderMateria(int id)
        {
            if (_context.tbMaterias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tbMaterias'  is null.");
            }
            var tbMaterias = await _context.tbMaterias.FindAsync(id);
            if (tbMaterias != null)
            {
                tbMaterias.Estado = 2;
                _context.tbMaterias.Update(tbMaterias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListaMaterias));
        }

        private bool tbMateriasExists(int id)
        {
            return (_context.tbMaterias?.Any(e => e.IdMateria == id)).GetValueOrDefault();
        }
    }
}
