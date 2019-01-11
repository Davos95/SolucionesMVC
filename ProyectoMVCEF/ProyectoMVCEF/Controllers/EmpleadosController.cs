using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class EmpleadosController : Controller
    {
        HelperEmpleados helper;

        public EmpleadosController()
        {
            this.helper = new HelperEmpleados();
        }

        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpleadosOficio
        public ActionResult EmpleadosOficio()
        {
            List<String> oficios = helper.GetOficios();
            ViewBag.Oficios = oficios;
            return View();
        }

        // POST: EmpleadosOficio
        [HttpPost]
        public ActionResult EmpleadosOficio(String oficio)
        {
            List<String> oficios = helper.GetOficios();
            List<EMP> empleados = this.helper.GetEmpleadosOficio(oficio);
            ResumenEmpleados resumen = this.helper.GetResumenEmpleados(oficio);

            ViewBag.Oficios = oficios;
            ViewBag.Resumen = resumen;
            return View(empleados);
        }

        //GET: EmpleadosDepartamento
        public ActionResult EmpleadosDepartamento()
        {
            List<DEPT> departamentos = helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadosDepartamento(int departamento)
        {
            List<EMP> empleados = helper.GetEmpleadosDepartamentos(departamento);
            ResumenEmpleados resumen = this.helper.GetResumenEmpleadosDepartamento(departamento);

            List<DEPT> departamentos = helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            ViewBag.Resumen = resumen;
            return View(empleados);
        }

        public ActionResult OrdenarEmpleados(int? ordenGet)
        {
           
            if (ordenGet is null)
            {
                ViewBag.Empleados = helper.GetEmpleados();
            } else
            {
                ViewBag.Empleados = helper.GetEmpleadosOrdenados(ordenGet.Value);
                ViewBag.orden = ordenGet;
            }
            
            return View();
        }

        public ActionResult PaginarEmpleadosSimple(int? posicion)
        {
            if(posicion == null)
            {
                posicion = 1;
            }
            int siguiente = posicion.GetValueOrDefault() + 1;
            int anterior = posicion.GetValueOrDefault() - 1;
            int ultimo = this.helper.GetNumeroEmpleados();
            //Comprobamos los valores de las posiciones
            if(anterior < 1)
            {
                anterior = 1;
            }
            if (siguiente > ultimo)
            {
                siguiente = ultimo;
            }
            ViewBag.Anterior = anterior;
            ViewBag.Siguiente = siguiente;
            ViewBag.Ultimo = ultimo;
            ViewBag.Mensaje = "Resgitro " + posicion + " de " + ultimo;
            PAGINAREMPLEADOSSIMPLE_Result empleados = helper.GetEmpleadosPaginados(posicion.GetValueOrDefault());
            return View(empleados);
        }

        public ActionResult PaginarDoctoresSimple(int? posicion)
        {
            if(posicion == null)
            {
                posicion = 1;
            }
            int siguiente = posicion.GetValueOrDefault() + 1;
            int anterior = posicion.GetValueOrDefault() - 1;
            int ultimo = this.helper.GetNumeroDoctores();
            if(anterior < 1)
            {
                anterior = 1;
            }
            if(siguiente > ultimo)
            {
                siguiente = 1;
            }
            ViewBag.Anterior = anterior;
            ViewBag.Siguiente = siguiente;
            ViewBag.Ultimo = ultimo;
            ViewBag.Mensaje = "Resgitro " + posicion + " de " + ultimo;
            PAGINARDOCTORES_Result doctor = helper.GetDoctoresPaginados(posicion.GetValueOrDefault());
            return View(doctor);
        }

        public ActionResult ParametrosSalida()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ParametrosSalida(int departamento)
        {
            ResumenEmpleados resumen = this.helper.GetResumenParametrosSalida(departamento);
            return View(resumen);
        }

        public ActionResult PaginarGrupo(int? posicion)
        {
            if(posicion == null)
            {
                posicion = 1;
            }

            int totalRegistros = 0;
            List<PAGINACIONEMPLEADOSAGRUPADOS_Result> empleados = this.helper.GetEmpleadosAgrupados(posicion.GetValueOrDefault(), ref totalRegistros);
            
            ViewBag.TotalRegistros = totalRegistros;
            return View(empleados);
        }

        public ActionResult PaginarPorSalario(int? posicion, int? salario)
        {
            if(salario == null)
            {
                salario = 0;
            }
            if(posicion == null)
            {
                posicion = 1;
            }
            int totalRegistros = 0;
            List<PAGINACIONDOCTORESAGRUPADOS_Result1> empleados = this.helper.GetTodosLosEmpleados(posicion.GetValueOrDefault(), salario.GetValueOrDefault(), ref totalRegistros);
            ViewBag.TotalRegistros = totalRegistros;
            ViewBag.Salario = salario.GetValueOrDefault();
            return View(empleados);
        }

        [HttpPost]
        public ActionResult PaginarPorSalario(int? posicion, int salario)
        {
            posicion = 1;

            int totalRegistros = 0;
            List<PAGINACIONDOCTORESAGRUPADOS_Result1> empleados = this.helper.GetTodosLosEmpleados(posicion.GetValueOrDefault(), salario, ref totalRegistros);
            ViewBag.TotalRegistros = totalRegistros;
            ViewBag.Salario = salario;

            return View(empleados);
        }

        public ActionResult PaginarConLinQ(int? posicion)
        {
            if(posicion == null)
            {
                posicion = 1;
            }
            
            int totalRegistros = 0;
            List<TODOSEMPLEADOS> empleados = this.helper.GetPaginarLinQ(posicion.GetValueOrDefault(), ref totalRegistros);

            String html = "";
            int numPagina = 1;
            for (int i = 1; i < totalRegistros; i+=3)
            {
                html += "<a href='PaginarConLinQ?posicion=" + i + "' class='btn btn-deafult'>" + numPagina + "</a>";
                numPagina++;
            }
            ViewBag.html = html;
            ViewBag.TotalRegistros = totalRegistros;
            return View(empleados);
        }
        public ActionResult SeleccionMultiple()
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            return View();
        }

        [HttpPost]
        public ActionResult SeleccionMultiple(int[] departamento)
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            List<EMP> empleados = this.helper.GetEmpleadosDepartamentoMultiple(departamento);

            return View(empleados);
        }
    }

    
}