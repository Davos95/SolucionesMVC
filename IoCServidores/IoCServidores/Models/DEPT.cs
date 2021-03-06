﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoCServidores.Models
{
    [Table("DEPT")]
    public class DEPT
    {
        [Key]
        [Column("DEPT_NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nDepartamento { get; set; }

        [Column("DNOMBRE")]
        public String Nombre { get; set; }

        [Column("LOC")]
        public String Localidad { get; set; }

    }
}