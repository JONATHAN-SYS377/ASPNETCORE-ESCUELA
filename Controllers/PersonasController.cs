using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;
using Microsoft.AspNetCore.Authorization;

namespace Escuela_Sor_Maria.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Tepiciones Get´para optener loas prov, cant, dist, barrio
        public IActionResult GetProvincias()
        {
            var provincias = _context.tbProvincia.Select(p => new { value = p.Cod, text = p.Nombre }).ToList();
            return Json(provincias);
        }

        public IActionResult GetCantones(string provinciaId)
        {
            var cantones = _context.tbCanton
                .Where(c => c.ProvinciaID == provinciaId)
                .Select(c => new { value = c.Canton, text = c.Nombre })
                .ToList();
            return Json(cantones);
        }

        public IActionResult GetDistritos(string provinciaId, string cantonId)
        {
            var distritos = _context.tbDistrito
                .Where(d => d.ProvinciaID == provinciaId && d.CantonID == cantonId)
                .Select(d => new { value = d.Distrito, text = d.Nombre })
                .ToList();
            return Json(distritos);
        }

        public IActionResult GetBarrios(string provinciaId, string cantonId, string distritoId)
        {
            var barrios = _context.tbBarrios
                .Where(b => b.ProvinciaID == provinciaId && b.CantonID == cantonId && b.DistritoID == distritoId)
                .Select(b => new { value = b.Barrio, text = b.Nombre })
                .ToList();
            return Json(barrios);
        }
        #endregion


        [Authorize]
        // GET: Personas
        public async Task<IActionResult> ListaPersonas()
        {
            return _context.tbPersona != null ?
                        View(await _context.tbPersona.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.tbPersona'  is null.");
        }

        public async Task<IActionResult> ListaPublica()
        {
            return _context.tbPersona != null ?
                        View(await _context.tbPersona.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.tbPersona'  is null.");
        }
        // GET: Personas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.tbPersona == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.tbPersona
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (tbPersona == null)
            {
                return NotFound();
            }

            return View(tbPersona);
        }

        // GET: Personas/Create
        public IActionResult CrearPersona()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPersona([Bind("Cedula,Nombre,Apellido1,Apellido2,FechaNacimiento,Sexo,Telefono,ProvinciaID,CantonID,DistritoID,BarrioID,Direccion")] tbPersona tbPersona)
        {
            if (ModelState.IsValid)
            {
                bool personaExists = await _context.tbPersona.AnyAsync(p => p.Cedula == tbPersona.Cedula);
                if (!personaExists)
                {
                    _context.Add(tbPersona);
                    await _context.SaveChangesAsync();
                   return RedirectToAction(nameof(ListaPersonas));
                }
                else
                {
                    ModelState.AddModelError("Cedula", "La persona ya existe en la base de datos.");
                }


            }
            return View(tbPersona);
        }



        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tbPersona == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.tbPersona.FindAsync(id);
            if (tbPersona == null)
            {
                return NotFound();
            }
            return View(tbPersona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,Apellido1,Apellido2,FechaNacimiento,Sexo,Telefono,ProvinciaID,CantonID,DistritoID,BarrioID,Direccion")] tbPersona tbPersona)
        {
            if (id != tbPersona.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbPersonaExists(tbPersona.Cedula))
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
            return View(tbPersona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tbPersona == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.tbPersona
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (tbPersona == null)
            {
                return NotFound();
            }

            return View(tbPersona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tbPersona == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tbPersona'  is null.");
            }
            var tbPersona = await _context.tbPersona.FindAsync(id);
            if (tbPersona != null)
            {
                _context.tbPersona.Remove(tbPersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbPersonaExists(string id)
        {
            return (_context.tbPersona?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
