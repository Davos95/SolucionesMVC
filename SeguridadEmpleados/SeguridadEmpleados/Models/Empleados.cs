using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SeguridadEmpleados.Models
{
    [Table("EMP")]
    public class Empleados: IPrincipal
    {
        [Key]
        [Column("EMP_NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmpleado { get; set; }

        [Column("APELLIDO")]
        public String Apellido { get; set; }

        [Column("OFICIO")]
        public String oficio { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }

        [Column("DIR")]
        public int Director { get; set; }


        //PARA CREAR USUARIOS PRINCIAL, QUÉ NECESITAMOS?
        //public Empleados(IIdentity identity, String[] roles)
        //{
        //    this.Identity = identity;
        //    this.Roles = roles;
        //}

        //private String[] Roles;

        public Empleados(IIdentity identity)
        {
            this.Identity = identity;
        }

        public Empleados() { }


        public bool IsInRole(string role)
        {
            if(this.oficio.ToUpper() == role.ToUpper())
            {
                return true;
            }
            return false;

            //if (this.Roles.Contains(role.ToUpper()))
            //{
            //    return true;
            //}
            //return false;
        }

        public IIdentity Identity { get; set; }
    }
}