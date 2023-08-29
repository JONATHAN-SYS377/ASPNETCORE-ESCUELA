using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Identity;

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
            var alumnosConMatriculas = await _context.tbAlumnos.ToListAsync();

            var alumnosViewModel = new List<ViewModelEstudianteMatricula>();

            foreach (var alumno in alumnosConMatriculas)
            {
                var matriculas = await _context.tbMatriculas
                    .Where(matricula => matricula.CedulaID == alumno.Cedula)
                    .ToListAsync();

                foreach (var matricula in matriculas)
                {
                    matricula.Cursos = await _context.tbCursos
                        .FirstOrDefaultAsync(curso => curso.IdCurso == matricula.CursoID);
                }

                var alumnoViewModel = new ViewModelEstudianteMatricula
                {
                    Alumno = alumno,
                    Matriculas = matriculas
                };

                alumnosViewModel.Add(alumnoViewModel);
            }

            return View(alumnosViewModel);
            //var alumnosConMatriculas = await _context.tbAlumnos.ToListAsync();

            //var alumnosViewModel = new List<ViewModelEstudianteMatricula>();

            //foreach (var alumno in alumnosConMatriculas)
            //{
            //    var matriculas = await _context.tbMatriculas
            //.Where(matricula => matricula.CedulaID == alumno.Cedula)
            //.Include(matricula => matricula.CursoID) // Incluir el curso en la unión
            //.ToListAsync(); ;

            //    var alumnoViewModel = new ViewModelEstudianteMatricula
            //    {
            //        Alumno = alumno,
            //        Matriculas = matriculas
            //    };

            //    alumnosViewModel.Add(alumnoViewModel);
            //}

            //return View(alumnosViewModel);
        }



        // GET: Alumnos/Details/5
        public async Task<IActionResult> Informacion(string id)
        {
            if (id == null || _context.tbAlumnos == null)
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
                FechaNacimiento = p.FechaNacimiento,
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
                CursosMatriculados = _context.tbMatriculas
                    .Where(matricula => matricula.CedulaID == p.Cedula)
                    .ToList()
                    })
                    .FirstOrDefaultAsync();
            if (personasConUbicaciones == null)
            {
                return View();
            }
            foreach (var matricula in personasConUbicaciones.CursosMatriculados)
                 {
                     matricula.Cursos = await _context.tbCursos
                            .FirstOrDefaultAsync(curso => curso.IdCurso == matricula.CursoID);
                  }
           
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
        public async Task<IActionResult> RegistrarAlumno(tbAlumnos tbAlumnos)
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
        public async Task<IActionResult> Actualizar(string id)
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
        public async Task<IActionResult> Actualizar(string id, tbAlumnos tbAlumnos)
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
                return RedirectToAction(nameof(ListaAlumnos));
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


        public IActionResult Matricularse(string id)
        {
            if (id == null || _context.tbAlumnos == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.tbCursos.Where(C => C.Estado == 1), "IdCurso", "NombreCursoo");

            var estudiantes = _context.tbAlumnos
                .Where(a => a.Cedula == id)
                .Select(a => new
                {
                    Value = a.Cedula,
                    Text = $"{a.Nombre} {a.Aoellido1} {a.Apellido2}"
                })
                .ToList();

            ViewData["Estudiante"] = new SelectList(estudiantes, "Value", "Text");
            return View();
        }

        // POST: TbMatriculas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Matricularse(TbMatriculas tbMatriculas)
        {
            if (!ModelState.IsValid)
            {
                var registroAnterior = await _context.tbMatriculas
                        .OrderByDescending(m => m.id)
                      .FirstOrDefaultAsync();
                if (registroAnterior != null)
                {
                    int ultimoId = registroAnterior.id+1;
                    tbMatriculas.id = ultimoId;
                    _context.Add(tbMatriculas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListaAlumnos));
                }
                else
                {
                    int ultimoId = 1;
                    tbMatriculas.id = ultimoId;
                    _context.Add(tbMatriculas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListaAlumnos));
                }
            }
            ViewData["CursoID"] = new SelectList(_context.tbCursos.Where(C => C.Estado == 1), "IdCurso", "NombreCursoo");

            var estudiantes = _context.tbAlumnos
                .Where(a => a.Cedula == tbMatriculas.CedulaID)
                .Select(a => new
                {
                    Value = a.Cedula,
                    Text = $"{a.Nombre} {a.Aoellido1} {a.Apellido2}"
                })
                .ToList();

            ViewData["Estudiante"] = new SelectList(estudiantes, "Value", "Text");
            return View(tbMatriculas);
        }

        public IActionResult Modal()
        {
            return View();
        }

      















        private bool tbAlumnosExists(string id)
        {
            return (_context.tbAlumnos?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
