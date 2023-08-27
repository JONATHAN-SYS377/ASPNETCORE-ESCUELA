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
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> ListaAlumnos()
        {
              return _context.tbAlumnos != null ? 
                          View(await _context.tbAlumnos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.tbAlumnos'  is null.");
        }



        // GET: Alumnos/Details/5
        public async Task<IActionResult> Informacion(string id)
        {
            if (id == null || _context.tbPersona == null)
            {
                return NotFound();
            }

            var provincias = await _context.tbProvincia.ToListAsync();
            var cantones = await _context.tbCanton.ToListAsync();
            var distritos = await _context.tbDistrito.ToListAsync();
            var barrios = await _context.tbBarrios.ToListAsync();

            var personasConUbicaciones = await _context.tbAlumnos.Where(p => p.Cedula == id && p.Estado == 1)
            .Select(p => new Alumno_Ubicacion
            {
                Cedula = p.Cedula,
                Nombre = p.Nombre,
                Aoellido1 = p.Aoellido1,
                Apellido2 = p.Apellido2,
                Sexo = p.Sexo,
                FechaNacimiento =  p.FechaNacimiento,
                Edad = p.Edad,
                ProvinciaID = Metodos.Metodos.ObtenerNombreProvincia(provincias, p.ProvinciaID),
                CantonID = Metodos.Metodos.ObtenerNombreCanton(cantones, p.CantonID, p.ProvinciaID),
                DistritoID = Metodos.Metodos.ObtenerNombreDistrito(distritos, p.DistritoID, p.CantonID, p.ProvinciaID),
                BarrioID = Metodos.Metodos.ObtenerNombreBarrio(barrios, p.BarrioID, p.DistritoID, p.CantonID, p.ProvinciaID),
                Direccion = p.Direccion,
                Estado = p.Estado,
                CedulaEncargado = p.CedulaEncargado,
                ContactoEmergencia = p.ContactoEmergencia,
                EncargadoLegal = p.EncargadoLegal,
            })
            .FirstOrDefaultAsync();

            return View(personasConUbicaciones);
        }

        // GET: Alumnos/Create
        public IActionResult RegistrarAlumno()
        {
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarAlumno([Bind("Cedula,Nombre,Aoellido1,Apellido2,Sexo,FechaNacimiento,Edad,ProvinciaID,CantonID,DistritoID,BarrioID,Direccion,CedulaEncargado,EncargadoLegal,ContactoEmergencia")] tbAlumnos tbAlumnos)
        {
            if (ModelState.IsValid)
            {
                tbAlumnos.Estado = 1;
                _context.Add(tbAlumnos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListaAlumnos));
            }
            return View(tbAlumnos);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tbAlumnos == null)
            {
                return NotFound();
            }

            var tbAlumnos = await _context.tbAlumnos.FindAsync(id);
            if (tbAlumnos == null)
            {
                return NotFound();
            }
            return View(tbAlumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,Aoellido1,Apellido2,Sexo,FechaNacimiento,Edad,ProvinciaID,CantonID,DistritoID,BarrioID,Direccion,CedulaEncargado,EncargadoLegal,ContactoEmergencia")] tbAlumnos tbAlumnos)
        {
            if (id != tbAlumnos.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAlumnos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbAlumnosExists(tbAlumnos.Cedula))
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
            return View(tbAlumnos);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tbAlumnos == null)
            {
                return NotFound();
            }

            var tbAlumnos = await _context.tbAlumnos
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (tbAlumnos == null)
            {
                return NotFound();
            }

            return View(tbAlumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tbAlumnos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tbAlumnos'  is null.");
            }
            var tbAlumnos = await _context.tbAlumnos.FindAsync(id);
            if (tbAlumnos != null)
            {
                _context.tbAlumnos.Remove(tbAlumnos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbAlumnosExists(string id)
        {
          return (_context.tbAlumnos?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
