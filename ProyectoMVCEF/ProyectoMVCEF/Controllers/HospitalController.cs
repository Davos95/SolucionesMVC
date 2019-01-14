using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class HospitalController : Controller
    {
        HelperHospital helper;
        public HospitalController()
        {
            helper = new HelperHospital();
        }
        public ActionResult PlantillaHospital(int?[] hospitales)
        {
            if (hospitales != null)
            {
                ViewBag.Hospitales = hospitales;
            }
            List<HOSPITAL> hospi = helper.GetHOSPITAL();
            return View(hospi);
        }

        [HttpPost]
        public ActionResult PlantillaHospital(int[] hospital, String orden)
        {

            List<PLANTILLA> plantilla = helper.GetPlantillaHospiatl(hospital, ref orden);
            ViewBag.Plantilla = plantilla;
            ViewBag.Ordenacion = orden;
            ViewBag.Hospitales = hospital; 
            List<HOSPITAL> hospitales = helper.GetHOSPITAL();
            return View(hospitales);
        }
    }
}