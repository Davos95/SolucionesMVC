using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetallesPersona()
        {
            List<Persona> personas = new List<Persona>();
            Persona p = new Persona("Carlos", "Tormo", 30, "Futbol");
            personas.Add(p);
            p = new Persona("Alejandro", "Gutierrez", 34, "Padel");
            personas.Add(p);
            p = new Persona("Pedro", "Casales", 35, "Running");
            personas.Add(p);
            p = new Persona("Adrian", "Ramos", 18, "Atletismo");
            personas.Add(p);
            p = new Persona("Fran", "Sanchez", 33, "Rugby");
            personas.Add(p);
            p = new Persona("Lucia", "Serrano", 12, "Curling");
            personas.Add(p);
            return View("DetallesPersona", personas);

        }


        /*
        public ActionResult RecuperarLenguajes()
        {
            Lenguajes lenguaje = new Lenguajes("C#", "Programación", "Microsoft");
            this.listalenguajes.Add(lenguaje);

            lenguaje = new Lenguajes("Java", "Programación", "Oracle");

            this.listalenguajes.Add(lenguaje);

            lenguaje = new Lenguajes("SQL Server", "Base de datos", "Microsoft");

            this.listalenguajes.Add(lenguaje);

            lenguaje = new Lenguajes("MySql", "Base de datos", "Oracle");

            this.listalenguajes.Add(lenguaje);

            lenguaje = new Lenguajes("Cobol", "Programación", "IBM");

            this.listalenguajes.Add(lenguaje);



            return View("DetallesLenguaje", this.listalenguajes);

        }
        */
    }
}