using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class AjaxController : Controller
    {
        RepositoryHospital repo;
        public AjaxController()
        {
            this.repo = new RepositoryHospital();
        }

        // GET: Ajax
        public ActionResult Index()
        {

            return View(this.repo.GetDepartamentos());
        }

        //EN VEZ DE USAR UN ACTIONRESULT UTILIZAMOS UN PARTIALRESULT
        //PARTIALVIEW ME OBLIGA A DEVOLVER return PartialView()
        public PartialViewResult _EmpleadosDepartamento(int deptno)
        {
            return PartialView(this.repo.GetEmpleadosDepartamento(deptno));
        }
    }
}