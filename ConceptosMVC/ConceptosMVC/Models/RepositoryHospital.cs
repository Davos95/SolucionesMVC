using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class RepositoryHospital
    {
        HospitalContext context;
        public RepositoryHospital()
        {
            this.context = new HospitalContext();
        }
        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }

        public List<Empleados> GetEmpleadosDepartamento (int deptno)
        {
            var consulta = from datos in context.Empleados
                           where datos.IdDepartamento == deptno
                           select datos;
            return consulta.ToList();
        }
    }
}