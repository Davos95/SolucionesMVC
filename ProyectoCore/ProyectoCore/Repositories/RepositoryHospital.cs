using ProyectoCore.Data;
using ProyectoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Repositories
{
    public class RepositoryHospital: IRepositoryHospital
    {
        IHospitalContext context;

        public RepositoryHospital(IHospitalContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }

        public void InsertarDepartamento(int num, String nombre, String loc)
        {
            Departamento departamento = new Departamento();
            departamento.Numero = num;
            departamento.Nombre = nombre;
            departamento.Localidad = loc;

            this.context.Departamentos.Add(departamento);
            this.context.SaveChanges();
        }
    }
}
