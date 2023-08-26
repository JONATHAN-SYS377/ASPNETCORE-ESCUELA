using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Escuela_Sor_Maria.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _Manager;

        public RolesController(RoleManager<IdentityRole> manager)
        {
            _Manager = manager;
        }

        public IActionResult Index()
        {
            var roles = _Manager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CrearRol()
        {
             
            return View();
        }


        [HttpPost]
        public IActionResult CrearRol(IdentityRole role)
        {
            if (!_Manager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _Manager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
