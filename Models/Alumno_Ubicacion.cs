using System.ComponentModel.DataAnnotations;

namespace Escuela_Sor_Maria.Models
{
    public class Alumno_Ubicacion
    {
        [Key]
        public string Cedula { get; set; }

        
        public string Nombre { get; set; }

        
        [Display(Name = "Primer Apellido")]

        public string Aoellido1 { get; set; }

        
        [Display(Name = "Segundo Apellido")]

        public string Apellido2 { get; set; }

        
        public string Sexo { get; set; }

        
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        
        public int Edad { get; set; }


        
        [Display(Name = "Provincia")]
        public string ProvinciaID { get; set; }

        
        [Display(Name = "Cantón")]
        public string CantonID { get; set; }

        
        [Display(Name = "Distrito")]
        public string DistritoID { get; set; }

        
        [Display(Name = "Barrio")]
        public string BarrioID { get; set; }

        
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        
        [Display(Name = "Cedula")]
        public string CedulaEncargado { get; set; }

        
        [Display(Name = "Nombre Completo")]
        public string EncargadoLegal { get; set; }

        
        [Display(Name = "Contacto de Emergencia")]
        public string ContactoEmergencia { get; set; }

        
        public int Estado { get; set; }

        [Display(Name = "Cursos Matriculados")]
        public List<TbMatriculas> CursosMatriculados { get; set; }
    }
}
