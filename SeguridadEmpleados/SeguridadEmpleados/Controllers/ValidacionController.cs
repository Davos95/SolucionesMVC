using SeguridadEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace SeguridadEmpleados.Controllers
{
    public class ValidacionController : Controller
    {
        RepositoryEmpleados repo;

        public ValidacionController()
        {
            this.repo = new RepositoryEmpleados();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(String apellido, int idempleado)
        {
            Empleados empleado = this.repo.ExisteEmpleado(apellido, idempleado);

            if(empleado != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, empleado.Apellido, DateTime.Now, DateTime.Now.AddMinutes(10),true, empleado.IdEmpleado.ToString());
                String cifrado = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("TICKETEMPLEADO", cifrado);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Empleados");
            } else
            {
                ViewBag.Mensaje = "Usuario/Password Incorrectos.";
            }
            return View();
        }

        // GET: ErrorAcceso
        public ActionResult ErrorAcceso()
        {
            return View();
        }

        

    }
}