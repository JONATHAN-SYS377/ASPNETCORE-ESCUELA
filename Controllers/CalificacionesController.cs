using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Rotativa.AspNetCore;

namespace Escuela_Sor_Maria.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public CalificacionesController(ApplicationDbContext context )
        {
            _context = context;
   
        }


        public IActionResult PdfNotas(string id)
        {
            var calificaciones = _context.tbCalificaciones
            .Include(t => t.Estudiante)
            .Include(t => t.Materia)
             .Where(t => t.Estudiante.Cedula == id);
            return new ViewAsPdf("PdfNotas", calificaciones)
            { 
            //FileName = $"Comprobante de Notas { id}.pdf",
            PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            PageSize = Rotativa.AspNetCore.Options.Size.A4

            };

        }






        // GET: Calificaciones
        public async Task<IActionResult> ListaMatriculados()
        {
            var applicationDbContext = _context.tbMatriculas
                .Include(a=>a.Estudiante)
                .Include(a=>a.Cursos)
                .Where(a=>a.Estudiante.Estado == 1);
            return View(await applicationDbContext.ToListAsync());
        }
         public async Task<IActionResult> ListaNotas(string id)
        {
            var applicationDbContext = _context.tbCalificaciones
        .Include(t => t.Estudiante)
        .Include(t => t.Materia)
        .Where(t => t.Estudiante.Cedula == id);

            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tbCalificaciones == null)
            {
                return NotFound();
            }

            var tbCalificaciones = await _context.tbCalificaciones
                .Include(t => t.Estudiante)
                .Include(t => t.Materia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tbCalificaciones == null)
            {
                return NotFound();
            }

            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Create
        public IActionResult RegistrarNota(string id)
        {
            CargarCombos(id);
            return View();

           
        }
        void CargarCombos(string id)
        {
            var estudiantes = _context.tbAlumnos
                            .Where(a => a.Cedula == id)
                            .Select(a => new
                            {
                                Value = a.Cedula,
                                Text = $"{a.Nombre} {a.Aoellido1} {a.Apellido2}"
                            })
                            .ToList();

            ViewData["Estudiante"] = new SelectList(estudiantes, "Value", "Text");
            ViewData["MateriaID"] = new SelectList(_context.tbMaterias, "IdMateria", "NombreMateria");
        }




        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarNota([Bind("id,CedulaEstudianteID,MateriaID,FechaCalificacion,NotaObtenida")] tbCalificaciones tbCalificaciones)
        {
            if (!ModelState.IsValid)
            {
                var registroAnterior = await _context.tbCalificaciones
                       .OrderByDescending(m => m.id)
                     .FirstOrDefaultAsync();
                if (registroAnterior != null)
                {
                    int ultimoId = registroAnterior.id + 1;
                    tbCalificaciones.id = ultimoId;
                    _context.Add(tbCalificaciones);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListaMatriculados));
                }
                else
                {
                    int ultimoId = 1;
                    tbCalificaciones.id = ultimoId;
                    _context.Add(tbCalificaciones);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListaMatriculados));
                }
            }
            CargarCombos(tbCalificaciones.CedulaEstudianteID);
            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> ActualizarNota( int? id)
        {
            if (id == null || _context.tbCalificaciones == null)
            {
                return NotFound();
            }

            var tbCalificaciones = await _context.tbCalificaciones.FindAsync(id);
            if (tbCalificaciones == null)
            {
                return NotFound();
            }
            CargarCombos(tbCalificaciones.CedulaEstudianteID);
            return View(tbCalificaciones);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarNota (int id, [Bind("id,CedulaEstudianteID,MateriaID,FechaCalificacion,NotaObtenida")] tbCalificaciones tbCalificaciones)
        {
            if (id != tbCalificaciones.id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCalificaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbCalificacionesExists(tbCalificaciones.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaMatriculados));
            }
            CargarCombos(tbCalificaciones.CedulaEstudianteID);
            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tbCalificaciones == null)
            {
                return NotFound();
            }

            var tbCalificaciones = await _context.tbCalificaciones
                .Include(t => t.Estudiante)
                .Include(t => t.Materia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tbCalificaciones == null)
            {
                return NotFound();
            }

            return View(tbCalificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tbCalificaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tbCalificaciones'  is null.");
            }
            var tbCalificaciones = await _context.tbCalificaciones.FindAsync(id);
            if (tbCalificaciones != null)
            {
                _context.tbCalificaciones.Remove(tbCalificaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbCalificacionesExists(int id)
        {
          return (_context.tbCalificaciones?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
