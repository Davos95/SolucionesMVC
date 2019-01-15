using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    [Table("DEPT")] 
    public class Departamento
    {
        [Key, Column("DEPT_NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "El numero es obligatorio")]
        public int Numero { get; set; }

        [Column("DNOMBRE")]
        [StringLength(50)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }

        [Column("LOC")]
        [Required(ErrorMessage = "La localidad es obligatoria")]
        public String Localidad { get; set; }
    }
}