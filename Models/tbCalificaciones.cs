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
        [Display(Name=" Nombre del Estudiante")]
        public string CedulaEstudianteID { get; set; }

        [Required]
        [ForeignKey(nameof(Materia))]
        public int MateriaID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = " Fecha de asignación de nota")]
        public  DateTime FechaCalificacion { get; set; }

        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Ingrese un valor numérico válido.")]
        [Display(Name = " Nota Obtenida")]
        public float NotaObtenida { get; set; }

        public virtual tbAlumnos Estudiante { get; set; }   

        public virtual tbMaterias Materia { get; set; }

    }
}
