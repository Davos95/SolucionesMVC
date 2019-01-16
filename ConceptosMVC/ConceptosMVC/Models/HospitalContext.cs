using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HospitalContext: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HospitalContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public HospitalContext() : base("name=cadenahospital") { }

        public HospitalContext(String cmstring) :base(cmstring) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}