using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

#region PROCEDIMIENTOS ALMACENADOS
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

CREATE PROCEDURE DATOSDEPARTAMENTOS
(@DEPTNO INT, @PERSONAS INT OUT, @SUMA INT OUT,@MEDIA INT OUT)
AS
	SELECT @PERSONAS = COUNT(EMP_NO), @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO)
	FROM EMP
	WHERE DEPT_NO = @DEPTNO
GO


ALTER PROCEDURE PAGINACIONEMPLEADOSAGRUPADOS
(@POSICION INT, @TOTALREGISTROS INT OUT)
AS
	SELECT @TOTALREGISTROS = COUNT(EMP_NO) FROM EMP
	SELECT * FROM
	(SELECT ROW_NUMBER() OVER (ORDER BY APELLIDO) AS POSICION, APELLIDO, SALARIO, OFICIO
	 FROM EMP
	 ) CONSULTA
	 WHERE POSICION >= @POSICION
	 AND POSICION < (@POSICION + 3);
GO


    ALTER PROCEDURE PAGINACIONDOCTORESAGRUPADOS
(@POSICION INT, @SALARIO INT, @TOTALREGISTROS INT OUT)
AS
	if(@SALARIO = NULL)
	BEGIN
	 SET @SALARIO = 5
	end
	SELECT @TOTALREGISTROS = COUNT(*) FROM TODOSLOSEMPLEADOS WHERE SALARIO >= @SALARIO;
	SELECT * FROM (
		SELECT ROW_NUMBER() OVER (ORDER BY APELLIDO) AS POSICION, *
		FROM TODOSLOSEMPLEADOS
		WHERE SALARIO >= @SALARIO
	) CONSULTA
	WHERE POSICION >= @POSICION
	AND POSICION < (@POSICION + 3);
GO	

    create VIEW TODOSEMPLEADOS
AS
	SELECT ISNULL(IDEMPLEADO,0) AS IDEMPLEADO, APELLIDO, CARGO, SALARIO FROM 
	(
		SELECT EMP_NO AS IDEMPLEADO, APELLIDO, OFICIO AS CARGO, SALARIO FROM EMP
		UNION ALL
		SELECT DOCTOR_NO, APELLIDO, ESPECIALIDAD, SALARIO FROM DOCTOR
		UNION ALL
		SELECT EMPLEADO_NO, APELLIDO, FUNCION, SALARIO FROM PLANTILLA
	) CONSULTA
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

        public ResumenEmpleados GetResumenParametrosSalida(int departamento)
        {
            //Los parametros de salida con entity framework se llaman con objetos de la clase ObjectParameter
            //Debemos indicar el nombre del parametro (sin @) y su tipo de dato
            ObjectParameter pamPersonas = new ObjectParameter("PERSONAS", typeof(int));
            ObjectParameter pamMedia = new ObjectParameter("MEDIA", typeof(int));
            ObjectParameter pamSuma = new ObjectParameter("SUMA", typeof(int));
            this.entity.DATOSDEPARTAMENTOS(departamento, pamPersonas, pamSuma, pamMedia);

            //COMPROBAR SI DEVUELVE VALOR EN LOS PARAMETROS
            if(pamSuma.Value == System.DBNull.Value)
            {
                return null; 
            }
            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = (int)pamPersonas.Value;
            resumen.MediaSalarial = (int)pamMedia.Value;
            resumen.SumaSalarial = (int)pamSuma.Value;
            return resumen;
        }

        //DEVOLVEMOS UNA COLECCION DE EMP (COMPLEX TYPE)
        public List<PAGINACIONEMPLEADOSAGRUPADOS_Result> GetEmpleadosAgrupados(int posicion, ref int totalRegistros)
        {
            ObjectParameter pamRegistros = new ObjectParameter("TOTALREGISTROS", typeof(int));

            //DEBERIAOS EXTRAER LOS DATOS DE LOS PROCEDIMIENTOS EN DOS PASOS
            var datos = this.entity.PAGINACIONEMPLEADOSAGRUPADOS(posicion, pamRegistros);
            
            
            List<PAGINACIONEMPLEADOSAGRUPADOS_Result> empleados = datos.ToList();
            totalRegistros = (int)pamRegistros.Value;
            return empleados;
        }

        public List<PAGINACIONDOCTORESAGRUPADOS_Result1> GetTodosLosEmpleados(int posicion, int salario, ref int totalRegistros)
        {
            ObjectParameter pamRegistros = new ObjectParameter("TOTALREGISTROS", typeof(int));
            var datos = this.entity.PAGINACIONDOCTORESAGRUPADOS(posicion, salario, pamRegistros);
            List<PAGINACIONDOCTORESAGRUPADOS_Result1> empleados = datos.ToList();
            totalRegistros = (int)pamRegistros.Value;

            return empleados;
        }

        public List<TODOSEMPLEADOS> GetPaginarLinQ(int posicion, ref int totalRegistros)
        {
            totalRegistros = this.entity.TODOSEMPLEADOS.Count();
            var consulta = this.entity.TODOSEMPLEADOS.OrderBy(x => x.APELLIDO).Skip(posicion).Take(3);
            List<TODOSEMPLEADOS> empleados = consulta.ToList();
            return empleados;
        }

        public List<EMP> GetEmpleadosDepartamentoMultiple(int[] departamentos)
        {
            var consulta = from datos in entity.EMP
                           where departamentos.Contains((int)datos.DEPT_NO)
                           select datos;

            return consulta.ToList();
        }
    }
}