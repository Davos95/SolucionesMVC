using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InyeccionEntity.Models
{
    public class HospitalContext: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //INDICAMOS QUE ESTAMOS ACCEDIENDO SOLAMENTE A SQL DESDE VISUAL STUDIO (una direccion)
            Database.SetInitializer<HospitalContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public HospitalContext(): base("name=cadenaHospital") { }


        public DbSet<Hospital> Hospitales { get; set; }

    }
}