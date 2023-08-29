using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Escuela_Sor_Maria.Models;
using Escuela_Sor_Maria.Data;

namespace Escuela_Sor_Maria.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(RoleManager<IdentityRole> Role, UserManager<IdentityUser> user,ApplicationDbContext context)
        {
            _roleManager = Role;
            _userManager = user;
            _context = context;
        }

        public IActionResult ListaRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol(IdentityRole role)
        {
            // Verificar si el rol existe   
            if (!await _roleManager.RoleExistsAsync(role.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return RedirectToAction(nameof(ListaRoles));

        }
        [HttpGet]
        public IActionResult CrearRol2()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol2(IdentityRole role)
        {
            // Verificar si el rol existe   
            if (!await _roleManager.RoleExistsAsync(role.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return RedirectToAction(nameof(ListaRoles));

        }

        [HttpGet]
        public IActionResult ListaUserRegistrados()
        {
            var roles = _roleManager.Roles.ToList();
            var users = _userManager.Users.ToList();
            var identityUserRoleList = new List<IdentityUserRole<string>>();
            var persona = _context.tbPersona.ToList();

            
            foreach (var user in users)
            {
                //Verificar si el usuario existe en la TbPersona
                

                var userRoles = _userManager.GetRolesAsync(user).Result;
                foreach (var roleName in userRoles)
                {
                    var role = _roleManager.Roles.Single(r => r.Name == roleName);
                    var identityUserRole = new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id };
                    identityUserRoleList.Add(identityUserRole);
                }
            }

            var viewmodel = new Usuarios
            {
                usuarios = users,
                roles = roles,
                rolesFk = identityUserRoleList,
                Profesores = persona
            };

                
            



            return View(viewmodel);
        }

        public IActionResult AsignarRolUser(string? ID)
        {

            var roles = _roleManager.Roles.Where(r => r.Name != "SuperUsuario").ToList();

            ViewBag.rol = roles;
            ViewBag.id = ID;

            return View();
        }

        [HttpPost]
        public IActionResult OtorgarRol(TbUnionUser_Role conten)
        {
            var users = _userManager.Users.Where(x => x.Id == conten.UserId ).FirstOrDefault();

            _userManager.AddToRoleAsync(users, conten.RoleName).GetAwaiter().GetResult();
            return RedirectToAction(nameof(ListaUserRegistrados));
        }

        [HttpPost]
        public IActionResult RevocarRol(TbUnionUser_Role conten)
        {
            var users = _userManager.Users.Where(x => x.Id == conten.UserId).FirstOrDefault();

            _userManager.RemoveFromRoleAsync(users, conten.RoleName).GetAwaiter().GetResult();
            return RedirectToAction(nameof(ListaUserRegistrados));
        }
    }
}
