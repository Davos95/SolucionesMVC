using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HelperDepartamento
    {
        EntidadHospital entity;
        public HelperDepartamento()
        {
            entity = new EntidadHospital();
        }

        public int GetMaxIdDepartamento()
        {
            int numero = (int)this.entity.GETMAXDEPTNO().FirstOrDefault();
            numero+= 10;
            return numero;
        }

        public void InsertarDepartamento(DEPT departamento)
        {
            entity.DEPT.Add(departamento);
            entity.SaveChanges();
        }

        public List<DEPT> GetDepartamentos()
        {
            var sql = entity.GETDEPT();
            List<DEPT> depts = sql.ToList();
            return depts;
        }
    }
}