using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriosHospital.Models;

namespace RepositoriosHospital.Contexts
{
    public class HospitalContextOracle : DbContext, IHospitalContext
    {
        public HospitalContextOracle(): base("name=cadenaHospitalOracle") { }
        public DbSet<DEPT> Departamentos { get; set; }

        //BASE DE DATOS ORACLE INDICAMOS EL ESQUEMA

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");
            base.OnModelCreating(modelBuilder);
        }
    }
}
