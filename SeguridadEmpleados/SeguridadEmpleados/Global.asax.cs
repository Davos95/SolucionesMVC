using SeguridadEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SeguridadEmpleados
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //SI NO ESCRIBIMOS BIEN EL METODO, NOS QUEDAMOS EN LOGIN
        public void Application_PostAuthenticateRequest()
        {
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            if(cookie != null)
            {
                String datos = cookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(datos);
                int empno = int.Parse(ticket.UserData);
                String username = ticket.Name;
                GenericIdentity identity = new GenericIdentity(username);
                //GenericPrincipal usuario = new GenericPrincipal(identity, roles);

                //DE DONDE SACO ESTE EMPLEADO?
                RepositoryEmpleados repo = new RepositoryEmpleados();
                Empleados empleado = repo.BuscarEmpleado(empno);
                empleado.Identity = identity;
                HttpContext.Current.User = empleado;

            }
        }
    }
}
