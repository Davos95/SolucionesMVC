using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriosHospital.Models;

namespace RepositoriosHospital.Contexts
{
    public class HospitalContextSQL : DbContext, IHospitalContext
    {
        public HospitalContextSQL() : base("Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2018") { }
        public DbSet<DEPT> Departamentos { get; set; }
    }
}
