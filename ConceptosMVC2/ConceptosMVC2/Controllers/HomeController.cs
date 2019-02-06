using ConceptosMVC2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.Controllers
{
    public class HomeController : Controller
    {
        RepositoryCulture repo;
        public HomeController()
        {
            this.repo = new RepositoryCulture();
        }

        // GET: Home
        public ActionResult Index(String cult)
        {
            if(cult != null)
            {
                this.repo.InitializeCulture(cult);
            }
            ViewBag.Fecha = DateTime.Now.ToLongDateString();
            ViewBag.Saludo = Resources.Mensajes.Saludo;
            ViewBag.Imagen = Resources.Mensajes.Imagen;

            return View();
        }
        
    }
}