using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaginaNoEncontrada()
        {
            Response.StatusCode = 404;
            ViewBag.Mensaje = "Recurso no encontrado en el servidor.";
            return View();
        }

        public ActionResult ErrorGeneral()
        {
            ViewBag.Mensaje = "Ha sudcedudo un error general";
            return View();
        }
    }
}