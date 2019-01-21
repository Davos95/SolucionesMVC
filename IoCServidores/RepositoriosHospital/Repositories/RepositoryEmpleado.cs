using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriosHospital.Contexts;
using RepositoriosHospital.Models;

namespace RepositoriosHospital.Repositories
{
   public  class RepositoryEmpleado : IRepositoryEmpleados
    {
        EntidadHospital entity;
        public RepositoryEmpleado(EntidadHospital entity)
        {
            this.entity = entity;
        }

        public EMP GetEmpleado(int num)
        {
            var consulta = from datos in entity.EMP
                           where datos.EMP_NO == num
                           select datos;
            return consulta.FirstOrDefault();
        }

        public List<EMP> GetEmpleados()
        {
            return this.entity.EMP.ToList();
        }
    }
}
