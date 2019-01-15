using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
namespace ConceptosMVC.Controllers
{
    public class DepartamentoController1 : Controller
    {
        HelperDepartamento helper;

        public DepartamentoController1()
        {
            helper = new HelperDepartamento();
        }

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearDepartamento()
        {
            DEPT d = new DEPT();
            d.DEPT_NO = this.helper.GetMaxIdDepartamento();
            return View(d);
        }
        
        [HttpPost]
        public ActionResult CrearDepartamento(DEPT departamento)
        {
            if (ModelState.IsValid)
            {
                this.helper.InsertarDepartamento(departamento);
                return View("Index");
            }

            DEPT d = new DEPT();
            d.DEPT_NO = this.helper.GetMaxIdDepartamento();
            return View(d);
        }
    }
}
*/