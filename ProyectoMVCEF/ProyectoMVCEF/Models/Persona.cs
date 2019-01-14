using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Apellido obligatorio")]
        public String Apellido {get; set;}

        [EmailAddress(ErrorMessage ="Direccion de mail incorrecta")]
        [Required]
        [Display(Description = "Correo electronico")]
        public String Email { get; set; }

        [DataType(DataType.Date)]
        public String FechaNacimiento { get; set; }

        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Compare("Password", ErrorMessage = "Password deben ser iguales")]
        [DataType(DataType.Password)]
        public String RepetirPass { get; set; }
        
    }
}