using SeguridadUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SeguridadUsuarios.Controllers
{
    public class ValidacionController : Controller
    {
        public object ControlUsuario { get; private set; }

        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(String usuario, String password)
        {
            //VALIDAR SI EL USUARIO QUE NOS HAN ENVIADO ES CORRECTO
            //SI ES CORRECTO, CREAMOS UN TICKET (cookie encriptada)
            ControlUsuarios control = new ControlUsuarios();
            if (control.ExisteUsuario(usuario, password))
            {
                //VERSION, FECHA CREACION, FECHA EXPIRACION, NAME(ID USER), DONDE ALMACENAR LA COOKIE, USERDATA(datos que no sirven. Es información extra del usuario)
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuario, DateTime.Now, DateTime.Now.AddMinutes(10), true, control.role);
                //ESTE TICKET SERÁ ALMACENADO EN UNA COOKIE, PARA QUE SEA UN TICKET VÁLIDO TENEMOS QUE ENCRIPTARLA
                String datoscifrados = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("TICKETUSUARIO", datoscifrados);
                //ALMACENAMOS LA COOKIE EN EL EXPLORADOR DEL CLIENTE
                Response.Cookies.Add(cookie);
                //ENVIAMOS A LA PAGINA DE ADMINISTRACION INDEX MANUALMENTE
                return RedirectToAction("Index", "Administracion");
            }
            return View();
        }
        //GET: ErrorAcceso
        public ActionResult ErrorAcceso()
        {
            return View();
        }
    }
}