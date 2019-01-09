using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region
/*
ALTER PROCEDURE PAGINAREMPLEADOSSIMPLE
(@POSICION INT)
AS
	SELECT * FROM (
	SELECT ROW_NUMBER() OVER (ORDER BY APELLIDO) AS POSICION, E.APELLIDO, E.OFICIO, E.SALARIO, D.DNOMBRE, D.LOC
	FROM EMP E
	INNER JOIN DEPT D
	ON E.DEPT_NO = D.DEPT_NO) CONSULTA
	WHERE POSICION = @POSICION;
GO

CREATE PROCEDURE PAGINARDOCTORES
(@POSICION INT)
AS 
	SELECT * FROM (
		SELECT ROW_NUMBER() OVER (ORDER BY APELLIDO) AS POSICION, D.APELLIDO, D.SALARIO, H.HOSPITAL, D.ESPECIALIDAD
		FROM DOCTOR D
		INNER JOIN HOSPITAL H
		ON D.HOSPITAL_COD = H.HOSPITAL_COD) CONSULTA
		WHERE POSICION = @POSICION;
GO

*/
#endregion
namespace ProyectoMVCEF.Models
{
    public class HelperEmpleados
    {
        EntidadHospital entity;
        public HelperEmpleados()
        {
            this.entity = new EntidadHospital();
        }

        public List<String> GetOficios()
        {
            var consulta = (from datos in entity.EMP
                           select datos.OFICIO).Distinct();
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosOficio(String oficio)
        {
            var consulta = from datos in entity.EMP
                           where datos.OFICIO == oficio
                           select datos;
            return consulta.ToList();
        }

        public ResumenEmpleados GetResumenEmpleados(string oficio)
        {
            List<EMP> empleados = this.GetEmpleadosOficio(oficio);
            int personas = empleados.Count;
            int? maximo = empleados.Max(x => x.SALARIO);
            System.Nullable<int> suma = empleados.Sum(z => z.SALARIO);
            double? media = empleados.Average(z => z.SALARIO);

            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = personas;
            resumen.SumaSalarial = suma.GetValueOrDefault();
            resumen.MaximoSalario = maximo.GetValueOrDefault();
            resumen.MediaSalarial = media.GetValueOrDefault();
            return resumen;
        }

        public List<DEPT> GetDepartamentos()
        {
            var consulta = from datos in entity.DEPT
                            select datos;
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosDepartamentos(int dep)
        {
            var consulta = from datos in entity.EMP
                           where datos.DEPT_NO == dep
                           select datos;
            return consulta.ToList();
        }

        public ResumenEmpleados GetResumenEmpleadosDepartamento(int dep) 
        {

            List<EMP> empleados = this.GetEmpleadosDepartamentos(dep);
            int personas = empleados.Count;
            int? maximo = empleados.Max(x => x.SALARIO);
            System.Nullable<int> suma = empleados.Sum(z => z.SALARIO);
            double? media = empleados.Average(z => z.SALARIO);

            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = personas;
            resumen.SumaSalarial = suma.GetValueOrDefault();
            resumen.MaximoSalario = maximo.GetValueOrDefault();
            resumen.MediaSalarial = media.GetValueOrDefault();
            return resumen;
        }

        public List<EMP> GetEmpleados()
        {
            var consulta = from datos in entity.EMP
                           select datos;
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosOrdenados(int orden)
        {
            if (orden == 0)
            {
                
                var consulta = (from datos in entity.EMP
                                select datos).OrderBy(x => x.APELLIDO);
                return consulta.ToList();
            } else
            {
                var consulta = (from datos in entity.EMP
                                select datos).OrderByDescending(x => x.APELLIDO);
                return consulta.ToList();
            }
            
        }

        public PAGINAREMPLEADOSSIMPLE_Result GetEmpleadosPaginados(int posicion)
        {
            PAGINAREMPLEADOSSIMPLE_Result empleados = entity.PAGINAREMPLEADOSSIMPLE(posicion).FirstOrDefault();
            return empleados;
        }
        public int GetNumeroEmpleados()
        {
            int datos = this.entity.EMP.Count();
            return datos;
        }

        public PAGINARDOCTORES_Result GetDoctoresPaginados(int posicion)
        {
            PAGINARDOCTORES_Result doctor = entity.PAGINARDOCTORES(posicion).FirstOrDefault();
            return doctor;
        }
        public int GetNumeroDoctores()
        {
            int datos = this.entity.DOCTOR.Count();
            return datos;
        }
    }
}