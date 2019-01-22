using SeguridadEmpleados.Atributos;
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
    [AutorizacionEmpleados]
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;
        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }

        // GET: Index
        public ActionResult Index()
        {
            //QUE NECESITAMOS
            //EL ID EMPLEADO VALIDADO
            //QUE TENEMOS?
            //TENEMOS AL USUARIO EN LA SESION
            //int empleado = HttpContext.User.Identity.Name;

            int empno = ((Empleados)HttpContext.User).IdEmpleado;
            List<Empleados> empleados = this.repo.GetEmpleadosSubordinados(empno);

            return View(empleados);
        }

        public ActionResult CerrarSesion()
        {
            //DEBEMOS QUITAR AL USUARIO Y SU IDENTIDAD
            HttpContext.User = new GenericPrincipal(new GenericIdentity(""), null);
            //SALIR DE LA AUTENTIFICACION
            FormsAuthentication.SignOut();
            //RECUPERAR LA COOKIE Y EXPIRARLA
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            cookie.Expires = DateTime.Now.AddYears(-1);
            //VOLVER A ESCRIBIR LA COOKIE
            Response.Cookies.Add(cookie);

            return View("Presentacion");
        }
        [AllowAnonymous]
        public ActionResult Presentacion()
        {
            return View();
        }

        //[AllowAnonymous] permitir a cualquiera
    }
}