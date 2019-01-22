using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeguridadEmpleados.Models
{
    public class EmpleadosContext : DbContext
    {

        public EmpleadosContext() : base("name=cadenaHospital") { }

        public DbSet<Empleados> Empleados { get; set; }

        
    }
}