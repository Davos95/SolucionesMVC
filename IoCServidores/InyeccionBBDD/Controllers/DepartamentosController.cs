using RepositoriosHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InyeccionBBDD.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryEmpleados repoEmple;

        public  DepartamentosController(IRepositoryEmpleados repoEmple)
        {
            this.repoEmple = repoEmple;
        }
        
        // GET: Index
        public ActionResult Index()
        {
            return View(this.repoEmple.GetEmpleados());
        }
        public ActionResult IdEmpleado(int? num)
        {
            return View(this.repoEmple.GetEmpleado(num.Value));
        }
    }
}