using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Models
{
    public class HospitalContext: DbContext
    {
        public HospitalContext() : base("name=cadenaHospital") { }
        public DbSet<Enfermo> Enfermos { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Excepcion> Excepciones { get; set; }
    }
}