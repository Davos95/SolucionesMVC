using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;

namespace ProyectoCore.Controllers
{
    public class CochesController : Controller
    {
        ICoche coche;
        public CochesController(ICoche coche)
        {
            this.coche = coche;
        }

        public IActionResult Index()
        {
            return View(this.coche);
        }

        [HttpPost]
        public IActionResult Index(String accion)
        {
            if(accion == "acelerar")
            {
                ViewData["MENSAJE"] = "Acelerando el coche";
                this.coche.Acelerar();
            }
            else
            {
                ViewData["MENSAJE"] = "Frenando el coche";
                this.coche.Frenar();
            }

            return View(this.coche);
        }
    }
}