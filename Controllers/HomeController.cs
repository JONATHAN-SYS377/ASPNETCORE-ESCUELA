using Escuela_Sor_Maria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Escuela_Sor_Maria.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MenuEstudiante()
        {
            return View();
        }

        public IActionResult MenuProfesor()
        {
            return View();
        }

        public IActionResult MenuMaterias()
        {
            return View();
        }

        public IActionResult MenuAsignarMaterias()
        {
            return View();
        }

        public IActionResult MenuCalificaciones()
        {
            return View();
        }

        public IActionResult MenuHorarios()
        {
            return View();
        }

        public IActionResult MenuReportes()
        {
            return View();
        }

        public IActionResult MenuRegistros()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}