using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela_Sor_Maria.Models
{
    public class TbMatriculas
    {
        [Key]
        public int id { get; set; }

        [ForeignKey(nameof(Estudiante))]
        public string CedulaID { get; set; }

        [ForeignKey(nameof(Cursos))]
        public int CursoID { get; set; }

        public virtual tbAlumnos Estudiante { get; set; }
        public virtual tbCursos Cursos { get; set; }
    }
}