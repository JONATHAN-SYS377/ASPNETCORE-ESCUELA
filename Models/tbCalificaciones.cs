using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela_Sor_Maria.Models
{
    public class tbCalificaciones
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey(nameof(Estudiante))]
        public string CedulaEstudianteID { get; set; }

        [Required]
        [ForeignKey(nameof(Materia))]
        public int MateriaID { get; set; }

        [Required]
        public  DateTime FechaCalificacion { get; set; }

        [Required]
        public float NotaObtenida { get; set; }

        public virtual tbAlumnos Estudiante { get; set; }   

        public virtual tbMaterias Materia { get; set; }

    }
}
