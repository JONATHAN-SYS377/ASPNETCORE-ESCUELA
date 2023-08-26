using System.ComponentModel.DataAnnotations;

namespace Escuela_Sor_Maria.Models
{
    public class tbProvicia
    {
        public class tbProvincia
        {
            [Key]
            public string Cod { get; set; }
            public string Nombre { get; set; }

            public ICollection<tbCanton> Cantones { get; set; }



        }
    }
}
