using ConceptosMVC2.Filters;
using ConceptosMVC2.Models;
using ConceptosMVC2.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.Controllers
{
    public class DoctoresController : Controller
    {

        RepositoryHospital repo;
        public DoctoresController()
        {
            this.repo = new RepositoryHospital();
        }

        // GET: Doctores
        public ActionResult Index()
        {
            return View(this.repo.GetDoctores());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HandleExceptionDoctor]
        [HttpPost]
        public ActionResult Create(Doctor doc )
        {
            if(doc.Salario > 650000)
            {
                throw new Exception("El doctor" + doc.Apellido + " no puede cobrar " + doc.Salario + ". El limite está en 650.000");
            } else if (doc.Especialidad.ToLower() == "neura" && doc.Salario < 300000)
            {
                throw new Exception("El doctor de Nuerolofia no puede cobrar menos de 300.000");
            }
            this.repo.InsertarDoctor(doc.IdDoctor, doc.CodigoHospital, doc.Apellido, doc.Especialidad, doc.Salario);
            return RedirectToAction("Index");
        }

        public ActionResult ErrorSalarios()
        {
            return View();
        }
        

    }
}