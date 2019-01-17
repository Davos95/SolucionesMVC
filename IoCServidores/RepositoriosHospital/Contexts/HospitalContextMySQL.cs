using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriosHospital.Models;

namespace RepositoriosHospital.Contexts
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HospitalContextMySQL : DbContext, IHospitalContext
    {
        public HospitalContextMySQL() : base("name=cadenaHospitalMySQL") { }
        public DbSet<DEPT> Departamentos { get; set; }
    }
}
