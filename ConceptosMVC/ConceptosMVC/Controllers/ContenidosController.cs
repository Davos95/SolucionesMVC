using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class ContenidosController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContenidoContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContenidoContent(String video)
        {
            int posicion = video.IndexOf("v=");

            String idvideo = video.Substring(posicion + 2);
            return Content("<iframe width='560' height='315'src = 'https://www.youtube.com/embed/" + idvideo + "' frameborder = '0'allowfullscreen ></ iframe > ");
            
        }

        public ActionResult ContenidoJavaScript()
        {
            
            return View();
        }

        public ActionResult CodigoJavaScript()
        {
            //Devolvemos el contenido mediante un Script de JavaScript
            String imagen = Url.Content("~/Images/2.jpg");
            String script = "$('#imagen').attr('src', '" + imagen + "');";
            
            return JavaScript(script);
        }

        public ActionResult ContenidoFile()
        {
            String path = Url.Content("~/Images/1.jpg");
            return File(path, "image/jpeg");
        }
        public ActionResult ContenidoJson()
        {
            Personaje p = new Personaje();
            p.Nombre = "Bruce";
            p.Apellido = "Banner";
            p.Profesion = "Justiciero";

            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}