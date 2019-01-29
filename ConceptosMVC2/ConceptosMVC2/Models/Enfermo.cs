using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Models
{
    [Table("ENFERMO")]
    public class Enfermo
    {
        [Key]
        [Column("INSCRIPCION")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inscripcion { get; set; }

        [Column("APELLIDO")]
        public String Apellido { get; set; }

        [Column("DIRECCION")]
        public String Direccion { get; set; }


    }
}