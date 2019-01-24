using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConceptosMVC.Models;
using ConceptosMVC.Repositories;
namespace ConceptosMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;
        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }


        // GET: Empleados
        public ActionResult Index()
        {
            List<Empleados> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public ActionResult AlmacenarSalarios(int? salario)
        {
            //Hemos recibido el salario
            if(salario != null)
            {
                int total = 0;
                //COMPROBAMOS SI EXISTE LA SESION
                if(Session["SALARIO"] != null)
                {
                    //RECUPERAMOS EL TOTAL QUE EXISTA DENTRO DE LA SESION
                    total = (int)Session["SALARIO"];
                }
                //SUMAMOS EL TOTAL CON EL SALARIO ENVIADO
                total += salario.Value;
                //ALMACENAMOS EL TOTAL EN LA SESION
                Session["SALARIO"] = total;
                ViewBag.Salario = "Salario recibido: " + salario;
            }
            List<Empleados> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public ActionResult MostrarSalarios()
        {
            ViewBag.Total = Session["SALARIO"];
            return View();
        }


        public ActionResult AlmacenarEmpleados(int? empno)
        {
            //PREGUNTAMOS SI RECIBIMOS ID
            if(empno != null)
            {
                //Si recibimos id, en la sesion almacenaremos una coleccion con los id de todos los empleados seleccionados
                List<int> codigoEmpleado;

                //COMPROBAMOS LA SESSION
                if(Session["EMPLEADOS"] == null)
                {
                    //Creamos la nueva coleccion de empleados
                    codigoEmpleado = new List<int>();

                } else
                {
                    //recuperamos la coleccion de la session
                    codigoEmpleado = (List<int>)Session["EMPLEADOS"];
                }
                //ALMACENAMOS EL EMP_NO EN LA COLECCION
                codigoEmpleado.Add(empno.Value);
                //GUARDAMOS LA COLECCION EN LA SESSION CON LOS CAMBIOS
                Session["EMPLEADOS"] = codigoEmpleado;
                ViewBag.Empleados = "Empleados almacenados: " + codigoEmpleado.Count();
            }
            //ENVIAMOS A LA VISTA EL CONJUNTO DE EMPLEADOS
            return View(this.repo.GetEmpleados());
        }

        public ActionResult MostrarEmpleados()
        {
            if(Session["EMPLEADOS"] != null)
            {
                //RECUPERAMOS LA COLECCION DE LA SESSION 
                List<int> codigos = (List<int>) Session["EMPLEADOS"];
                //BUSCAMOS LOS EMPLEADOS EN EL REPO
                List<Empleados> empleados = this.repo.BuscarEmpleadoSession(codigos);
                return View(empleados);

            }
            return View();
        }
    }
}