using RepositoriosHospital.Contexts;
using RepositoriosHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosHospital.Repositories
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        IHospitalContext context;
        public RepositoryDepartamento(IHospitalContext context)
        {
            this.context = context;
        }
        public List<DEPT> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }
    }
}
