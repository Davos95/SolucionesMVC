using ConceptosMVC.Models;
using ConceptosMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class PracticaAjaxController : Controller
    {
        RepositoryEmpleados repo;
        public PracticaAjaxController()
        {
            this.repo = new RepositoryEmpleados();
        }

        // GET: PracticaAjax
        public ActionResult Index()
        {

            return View(this.repo.GetEmpleados());
        }

        public PartialViewResult _DetallesEmpleado(int empno)
        {
            return PartialView(this.repo.GetEmpleadoID(empno));
        }

        public ActionResult EliminarEmpleado(int empno)
        {
            this.repo.DeleteEmpleado(empno);
            return RedirectToAction("Index");
        }
    }
}