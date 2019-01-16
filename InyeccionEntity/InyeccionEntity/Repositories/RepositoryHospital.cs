using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InyeccionEntity.Models;

namespace InyeccionEntity.Repositories
{
    public class RepositoryHospital : IRepositoryHospital
    {
        HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            return context.Hospitales.ToList();
        }

    }
}