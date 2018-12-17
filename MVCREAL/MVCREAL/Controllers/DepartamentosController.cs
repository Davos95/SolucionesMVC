using MVCREAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCREAL.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: Departamentos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarDepartamento()
        {
            return View();
        }
        //POST: BuscarDepartamento
        [HttpPost]
        public ActionResult BuscarDepartamento(int num)
        {
            HelperDepartamento helper = new HelperDepartamento();
            Departamento dept = helper.BuscarDepartamento(num);
            return View(dept);
        }
    }
}