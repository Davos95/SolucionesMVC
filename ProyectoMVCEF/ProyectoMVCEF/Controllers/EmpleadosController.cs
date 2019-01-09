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
    }
}