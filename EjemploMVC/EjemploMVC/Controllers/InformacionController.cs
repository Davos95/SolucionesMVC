using EjemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploMVC.Controllers
{
    public class InformacionController : Controller
    {
        // GET: Informacion
        public ActionResult Index()
        {
            return View();
        }

        //GET: ControladorVista
        public ActionResult ControladorVista()
        {
            //Para enviar información a l avista podemos hacerlo de dos maneras:
            //ViewData y ViewBag
            //Los dos objetos apuntan al mismo espacio de memoria, es decir, son el mismo objeto
            //no son CASESENSITIVE y permiten crear propiedades dinamicas con cualquier tipo de dato (object)
            //ViewData["PROPIEDAD"] = VALOR | ViewBag.Propiedad = VALOR
            ViewData["MENSAJE"] = "Mensaje desde el servidor";
            ViewBag.Mensaje = "Mensaje desde el ViewBag";
            ViewBag.Fecha = "14/12/2018";
            //Vamos a enviar a la vista un objeto Persona
            //Primero con VIEWBAG
            Persona person = new Persona();
            person.Nombre = "David";
            person.Apellidos = "Valencia";
            person.Edad = 23;
            ViewBag.Persona = person;
            return View();
        }

        //GET: ControladorVistaModel
        public ActionResult ControladorVistaModel()
        {
            Persona persona = new Persona();
            persona.Nombre = "David";
            persona.Apellidos = "Valencia";
            persona.Edad = 23;
            //Una vista solamente recibe un modelo
            //El modelo estara tipado en la vista
            //Se envia al devolver la vista
            // @model DECLARAR
            // @Model UTILIZAR

            return View(persona);
        }

        //GET: VistaControladorGet
        //La informacion se recibe como parametros
        //El nombre de los parametros debe ser igual al valor en el que se envian
        public ActionResult VistaControladorGet(String nombre, int? edad)
        {
            ViewBag.Nombre = nombre + ", "+edad;
            return View();
        }

        //GET: VistaControladorPost
        public ActionResult VistaControladorPost()
        {
            return View();
        }

        //POST: VistaControladorPost
        [HttpPost]
        public ActionResult VistaControladorPost(String cajamarca, String cajamodelo)
        {
            ViewBag.Descripcion = "Marca:" + cajamarca + ", Modelo: " + cajamodelo;
            return View();
        }
    }
}