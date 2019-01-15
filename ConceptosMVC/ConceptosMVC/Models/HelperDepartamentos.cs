using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HelperDepartamentos
    {
        HospitalContext context;
        public HelperDepartamentos()
        {
            this.context = new HospitalContext();
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public void InsertarDepartamento(int num, String nom, String loc)
        {
            Departamento departamento = new Departamento();
            departamento.Numero = num;
            departamento.Nombre = nom;
            departamento.Localidad = loc;
            this.context.Departamentos.Add(departamento);
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int num, String nom, String loc)
        {
            Departamento departamento = this.context.Departamentos.Single(z => z.Numero == num);
            departamento.Nombre = nom;
            departamento.Localidad = loc;
            this.context.SaveChanges();
        }

        public Departamento BuscarDepartamento(int deptno)
        {
            var consulta = from datos in context.Departamentos
                           where datos.Numero == deptno
                           select datos;
            return consulta.FirstOrDefault();
        }

        public int GetMaxDeptno()
        {
            var consulta = (from datos in context.Departamentos
                            select datos).OrderByDescending(x => x.Numero).FirstOrDefault();
            int max = consulta.Numero + 10;
            return max;
        }

    }
}