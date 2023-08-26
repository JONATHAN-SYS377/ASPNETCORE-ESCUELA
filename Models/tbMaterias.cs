using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela_Sor_Maria.Models
{
    public class tbMaterias
    {
        [Required]
        [ForeignKey(nameof(Curso))]
        public int CursoID { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreMateria { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey(nameof(Persona))]
        public string ProfesorAsignado { get; set; }

        [Required]
        public int Estado { get; set; }

        public virtual tbCursos Curso { get; set; }
        public virtual tbPersona Persona { get; set; }


    }
}
