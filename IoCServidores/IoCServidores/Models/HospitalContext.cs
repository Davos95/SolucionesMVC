using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IoCServidores.Models
{
    public class HospitalContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HospitalContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public HospitalContext() : base("name=cadenaHospital") { }

        public DbSet<DEPT> Departamentos { get; set; }

    }
}