using ConceptosMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Repositories
{
    public class RepositoryHospital
    {
        HospitalContext context;
        public RepositoryHospital()
        {
            context = new HospitalContext();
        }

        public List<Enfermo> GetEnfermos()
        {
            return this.context.Enfermos.ToList();
        }

        public Enfermo BuscarEnfermo(int inscripcion)
        {
            return this.context.Enfermos.Single(z => z.Inscripcion == inscripcion);
        }

        public void EliminarEnfermo(int inscripcion)
        {
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            this.context.Enfermos.Remove(enfermo);
            this.context.SaveChanges();
        }

    }
}