using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Repositories
{
    public class RepositoryEmpleados
    {
        HospitalContext context;
        public RepositoryEmpleados()
        {
            this.context = new HospitalContext();
        }

        public List<Empleados> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }
        public List<Empleados> BuscarEmpleadoSession(List<int> codigos)
        {
            var consulta = from datos in context.Empleados
                           where codigos.Contains(datos.IdEmpleado)
                           select datos;
            return consulta.ToList();
        }

        public Empleados GetEmpleadoID(int empno)
        {
            var consulta = from datos in context.Empleados
                           where datos.IdEmpleado == empno
                           select datos;
            return consulta.FirstOrDefault();
        }
        public void DeleteEmpleado(int empno)
        {
            Empleados empleado = GetEmpleadoID(empno);
            this.context.Empleados.Remove(empleado);
            this.context.SaveChanges();
        }
    }
}