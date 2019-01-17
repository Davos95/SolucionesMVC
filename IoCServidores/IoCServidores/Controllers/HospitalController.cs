using IoCServidores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoCServidores.Controllers
{
    public class HospitalController : Controller
    {
        IRepositoryDepartamento repo;
        public HospitalController(IRepositoryDepartamento repo)
        {
            this.repo = repo;
        }
        // GET: Hospital
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Departamentos()
        {
            return View(this.repo.GetDepartamentos());
        }
    }
}