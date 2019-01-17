using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoCServidores.Models;

namespace IoCServidores.Repositories
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        HospitalContext context;
        public RepositoryDepartamento(HospitalContext context)
        {
            this.context = context;
        }
        public List<DEPT> GetDepartamentos()
        {
            return context.Departamentos.ToList();
        }
    }
}