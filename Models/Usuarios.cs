using Microsoft.AspNetCore.Identity;

namespace Escuela_Sor_Maria.Models
{
    public class Usuarios
    {
        public List<IdentityUser>? usuarios { get; set; }
        public List<IdentityUserRole<string>>? rolesFk { get; set; }

        public List<IdentityRole>? roles { get; set; }

        //public TbUnionUser_Role User_Role { get; set; }
        public List<tbPersona>? Profesores { get; set; }
    }
}
