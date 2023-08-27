using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Escuela_Sor_Maria.Areas.Identity.Pages.Account.RegisterModel;

namespace Escuela_Sor_Maria.Models
{
    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2
    }

    public class tbProfesores
    {
        [Key]
        [Required]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido ")]
        public string Apellido1 { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }


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
        [Display(Name ="Condición del Docente")]
        public int Estado { get; set; }


    }
}
