using System.ComponentModel.DataAnnotations;

namespace Escuela_Sor_Maria.Models
{
    public class tbCursos
    {
        [Key]
        public int IdCurso { get; set; }

        [Required]
        [Display(Name = "Nombre del Curso")]
        public string NombreCursoo { get; set; }

        [Required]
        [Display(Name = "Descripción breve")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Nivel ('Basíco, Intermedio, Avanzado')")]
        public string Nivel  { get; set; }

        [Required]
        [Display(Name = "Duración del Curso ('Meses')")]
        public string Duracion { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}
