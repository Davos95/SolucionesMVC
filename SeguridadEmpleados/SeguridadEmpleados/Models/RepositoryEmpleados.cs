using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadEmpleados.Models
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;

        public RepositoryEmpleados() {
            this.context = new EmpleadosContext();
        }

        // METODO PARA DEVOLVER UN EMPLEADO POR APELLIDO Y EMPNO
        public Empleados ExisteEmpleado(String apellido, int empno)
        {
            var consulta = from datos in context.Empleados
                           where datos.Apellido == apellido 
                           && datos.IdEmpleado == empno
                           select datos;
            return consulta.FirstOrDefault();
        }

        // METODO PARA DEVOLVER LOS SUBORDINADOS DE UN EMPLEADO
        public List<Empleados> GetEmpleadosSubordinados(int director)
        {
            var consulta = from datos in context.Empleados
                           where datos.Director == director
                           select datos;
            if(consulta.Count() == 0)
            {
                return null;
            }

            return consulta.ToList();
        }

        // METODO PARA BUSCAR EN EMPLEADO POR SU EMPNO
        public Empleados BuscarEmpleado(int empno)
        {
            var consulta = from datos in context.Empleados
                           where datos.IdEmpleado == empno
                           select datos;
            return consulta.FirstOrDefault();
        }

        // METODO PARA MODIFICAR UN EMPLEADO
        public void ModificarEmpleado(int empno, String apellido, String oficio, int salario)
        {
            Empleados emp = this.BuscarEmpleado(empno);
            emp.Apellido = apellido;
            emp.oficio = oficio;
            emp.Salario = salario;
            this.context.SaveChanges();
        }

    }
}