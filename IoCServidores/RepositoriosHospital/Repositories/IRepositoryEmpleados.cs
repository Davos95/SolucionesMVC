using RepositoriosHospital.Contexts;
using RepositoriosHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosHospital.Repositories
{
    public interface IRepositoryEmpleados
    {
        List<EMP> GetEmpleados();

        EMP GetEmpleado(int num);
    }
}
