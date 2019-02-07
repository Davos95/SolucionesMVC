using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ProyectoCore.Extensions;

namespace ProyectoCore.Controllers
{
    public class HomeController : Controller
    {
        ILogger log; 
        public HomeController(ILogger<HomeController> log)
        {
            this.log = log;
        }

        public IActionResult Index()
        {

            log.LogInformation("Estoy en Home/Index");
            return View();
        }

        public IActionResult About(String usuario)
        {
            log.LogInformation("Estoy en Home/About");
            String texto = "Hoy es jueves";
            texto.GetNumeroPalabras();
            ViewData["SALUDO"] = "Hola usuario " + usuario;
            return View();
        }
        public IActionResult Donativos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Donativos(String nombre, int cantidad)
        {
            ViewData["Mensaje"] = "El Sr/Sra " + nombre + " ha donado la cantidad de " + cantidad + "€";

            Trace.TraceInformation(nombre + " " + cantidad + "€.");
            MetricTelemetry metrica = new MetricTelemetry();
            metrica.Name = "Donativos";
            metrica.Sum = cantidad;
            TelemetryClient client = new TelemetryClient();
            client.TrackEvent("Evento Donativos");
            client.TrackMetric(metrica);


            return View();
        }
        public IActionResult MiSesion(String accion)
        {
            
            if(accion == null || accion == "guardar")
            {
                ViewData["MENSAJE"] = "Guardada Sesion";

                HttpContext.Session.SetObject("hola", 1);

                HttpContext.Session.SetString("Nombre","David");
                HttpContext.Session.SetInt32("Edad", 23);
            } else
            {
                ViewData["MENSAJE"] = "Almacenando Session";
                ViewData["NOMBRE"] = HttpContext.Session.GetString("Nombre");
                ViewData["EDAD"] = HttpContext.Session.GetInt32("Edad");
            }
            return View();
        }
    }
}