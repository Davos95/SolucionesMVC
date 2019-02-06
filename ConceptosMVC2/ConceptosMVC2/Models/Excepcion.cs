using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Models
{
    [Table("EXCEPCIONES")]
    public class Excepcion
    {
        [Key]
        [Column("IDEXCEPCION")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdExcepcion { get; set; }
        [Column("MENSAJE")]
        public String Mensaje { get; set; }
        [Column("CONTROLADOR")]
        public String Contorlador { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }
    
}