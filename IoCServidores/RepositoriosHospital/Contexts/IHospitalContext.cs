using RepositoriosHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosHospital.Contexts
{
    public interface IHospitalContext
    {
        DbSet<DEPT> Departamentos { get; set; }
    }

}
