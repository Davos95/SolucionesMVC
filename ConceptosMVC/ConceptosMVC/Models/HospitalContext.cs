using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HospitalContext: DbContext
    {
        public HospitalContext() : base("name=cadenahospital") { }

        public HospitalContext(String cmstring) :base(cmstring) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}