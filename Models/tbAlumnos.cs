using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela_Sor_Maria.Models
{
    public class tbAlumnos
    {
        [Key]
        public  string  Cedula { get; set; }

        [Required]
        public string Nombre  { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]

        public string Aoellido1  { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]

        public string Apellido2  { get; set; }

        [Required]
        public string Sexo  { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int Edad { get; set; }


        [Required]
        [Display(Name = "Provincia")]
        public string ProvinciaID { get; set; }

        [Required]
        [Display(Name = "Cantón")]
        public string CantonID { get; set; }

        [Required]
        [Display(Name = "Distrito")]
        public string DistritoID { get; set; }

        [Required]
        [Display(Name = "Barrio")]
        public string BarrioID { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Cedula Padre o Madre")]
        public string CedulaEncargado { get; set; }

        [Required]
        [Display(Name = "Nombre Padre o Madre")]
        public string EncargadoLegal { get; set; }

        [Required]
        [Display(Name = "Contacto de Emergencia")]
        public string ContactoEmergencia { get; set; }

        [Required]
        public int Estado { get; set; }


    }
}
