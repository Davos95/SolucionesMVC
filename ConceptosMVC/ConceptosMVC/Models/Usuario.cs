using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    [Table("USERSHASH")]
    public class Usuario
    {
       [Key]
       [Column("IDUSUARIO")]
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int IDUSUARIO { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }

        [Column("USUARIO")]
        public String nUsuario { get; set; }

        [Column("PASS")]
        public byte[] pass { get; set; }

        [Column("SALT")]
        public String salt { get; set; }
        
    }
}