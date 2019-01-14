using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class ValidacionesController : Controller
    {
        // GET: Correcto
        public ActionResult Correcto()
        {
            return View();
        }

        public ActionResult InsertarPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarPersona(Persona persona)
        {
            if (ModelState.IsValid)
            {
                //Nos los llevamos a correcto
                return View("Correcto");
            }
            //Enviamos de nuevo la persona
            return View();
        }
    }
}