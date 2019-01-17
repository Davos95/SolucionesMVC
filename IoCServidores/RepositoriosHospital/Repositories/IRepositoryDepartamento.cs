using RepositoriosHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosHospital.Repositories
{
   public interface IRepositoryDepartamento
    {
        List<DEPT> GetDepartamentos();
    }
}
