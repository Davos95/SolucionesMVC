using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class CachingController : Controller
    {
        // GET: Caching
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration = 5, VaryByParam = "dato", System.Web.UI.OutputCacheLocation = System.Web.UI.OutputCacheLocation.Server)]
        [OutputCache(CacheProfile = "perfil15")]
        //GET: HoraServidor
        public ActionResult HoraSistema(String dato)
        {
            ViewBag.Hora = "Fecha: "+DateTime.Now.ToLongDateString() + ". Hora: " + DateTime.Now.ToLongTimeString();
            return View();
        }
    }
}