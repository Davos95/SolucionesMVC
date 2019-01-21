using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SeguridadUsuarios
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        public void Application_PostAuthenticateRequest()
        {
            //ESTE METODO ENTRARA CUANDO HAYA CREADO EL TICKET
            //DEBEMOS RECUPERAR EL TICKET QUE ESTA EN LA COOKIE
            HttpCookie cookie = Request.Cookies["TICKETUSUARIO"];
            if(cookie != null)
            {
                //ESTAMOS EN EL SISTEMA (FACTOR UNO)
                //RECUPERAR EL TICKET DE LA COOKIE
                //NECESITAMOS LOS DATOS CIFRADOS
                String datoscifrados = cookie.Value;
                System.Web.Security.FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(datoscifrados);
                //HEMOS ALMACENADO EL USERNAME EN NAME
                //HEMOS ALMACENADO EL ROLE EN USERDATA
                String username = ticket.Name;
                String role = ticket.UserData;
                //UN USUARIO NORMAL, ES UN GENERIC PRINCIPAL
                //UN PRINCIPAL ESTÁ COMPUESTO POR UNA IDENTIDAD (NAME) Y POR LOS ROLES[]
                GenericIdentity identidad = new GenericIdentity(username);
                GenericPrincipal user = new GenericPrincipal(identidad, new String[] { role });
                //HAY QUE PONER AL USUARIO EN LA SESSION DE LA APLICACION
                HttpContext.Current.User = user;

            }
        }
    }
}
