using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCore.Controllers
{
    [Area("RealMadrid")]
    public class RealMadridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}