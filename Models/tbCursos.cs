using System.ComponentModel.DataAnnotations;

namespace Escuela_Sor_Maria.Models
{
    public class tbCursos
    {
        public int Id { get; set; }

        [Required]
        public string NombreGrado { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Nivel  { get; set; }

        [Required]
        public string Duracion { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}
