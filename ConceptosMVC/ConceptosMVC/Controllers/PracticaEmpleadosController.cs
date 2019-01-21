using ConceptosMVC.Models;
using ConceptosMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class PracticaEmpleadosController : Controller
    {
        RepositoryEmpleados repo;
        public PracticaEmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }
        // GET: PracticaEmpleados
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlmacenarEmpleadosSesion(int? empno)
        {
            
            if (empno != null)
            {
                List<int> empleados;
                if (Session["EMPLEADOS"] == null)
                {
                    empleados = new List<int>();
                } else
                {
                    empleados = (List<int>)Session["EMPLEADOS"];
                }
                empleados.Add(empno.Value);
                Session["EMPLEADOS"] = empleados;
                ViewBag.Mensaje = "Numero de empleados almacenados: " + empleados.Count();
            }
            return View(this.repo.GetEmpleados());
        }

        public ActionResult MostrarEmpleadosSesion(int? empno)
        {
            List<Empleados> empleados;
            if (Session["EMPLEADOS"] != null)
            {
                List<int> idEmpleados = (List<int>)Session["EMPLEADOS"];
                //Eliminamos el id
                if(empno != null)
                {
                    idEmpleados.Remove(empno.Value);
                    Session["EMPLEADOS"] = idEmpleados; //igualamos la sesion a la lista idEmpleados
                }

                empleados = this.repo.BuscarEmpleadoSession(idEmpleados);
            } else
            {
                return RedirectToAction("AlmacenarEmpleadosSesion");
            }

            int sumaSalarial = 0;
            foreach (Empleados emp in empleados)
            {
                sumaSalarial += emp.Salario;
            }
            ViewBag.sumaSalarial = sumaSalarial;

            return View(empleados);
        }
    }
}