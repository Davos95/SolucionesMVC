using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        HelperDepartamentos helper;

        public DepartamentosController()
        {
            helper = new HelperDepartamentos();
        }

        // GET: Departamentos
        public ActionResult Index()
        {
            List<Departamento> departamentos = this.helper.GetDepartamentos();
            return View(departamentos);
        }

        public ActionResult Create()
        {
            Departamento departamento = new Departamento();
            departamento.Numero = helper.GetMaxDeptno();
            
            return View(departamento);
        }

        [HttpPost]
        public ActionResult Create(Departamento dept)
        {
            this.helper.InsertarDepartamento(dept.Numero, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index", "Departamentos");
        }

        public ActionResult Edit(int id)
        {
            Departamento dept = this.helper.BuscarDepartamento(id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(Departamento dept)
        {
            this.helper.ModificarDepartamento(dept.Numero, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index","Departamentos");
        }

        [ChildActionOnly]
        public ActionResult _ParcialDepartamentos()
        {
            List<Departamento> departamentos = this.helper.GetDepartamentos();
            return PartialView(departamentos);
        }
    }
}