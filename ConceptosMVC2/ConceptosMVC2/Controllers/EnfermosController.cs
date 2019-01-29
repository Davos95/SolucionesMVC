using ConceptosMVC2.Models;
using ConceptosMVC2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.Controllers
{
    public class EnfermosController : Controller
    {
        RepositoryHospital repo;

        public EnfermosController()
        {
            this.repo = new RepositoryHospital();
        }

        // GET: Enfermos
        public ActionResult Index()
        {

            return View(this.repo.GetEnfermos());
        }

        //GET: DELETE
        public ActionResult Delete(int id)
        {
            Enfermo enfermo = this.repo.BuscarEnfermo(id);
            return View(enfermo);
        }

        //POST: DELETE
        [HttpPost]
        public ActionResult EliminarEnfermo(int inscripcion)
        {
            this.repo.EliminarEnfermo(inscripcion);
            return RedirectToAction("Index");
        }
    }
}