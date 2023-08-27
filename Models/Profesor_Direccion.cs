using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Escuela_Sor_Maria.Models
{
    public class Profesor_Direccion
    {
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

 
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
 
        [Display(Name = "Primer Apellido ")]
        public string Apellido1 { get; set; }

 
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }
 
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

 
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

 
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

 
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
 
        [Display(Name = "Condición del Docente")]
        public string Estado { get; set; }


        // FALTA AGREGAR LOS DATOS DE LA MATERIA Q IMPARTE
    }
}
