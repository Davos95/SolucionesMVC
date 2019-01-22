using SeguridadEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeguridadEmpleados.Atributos
{
    public class AutorizacionEmpleadosAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //GenericPrincipal usuario = (GenericPrincipal) filterContext.HttpContext.User;
                Empleados empleado = filterContext.HttpContext.User as Empleados;

                if (empleado.oficio != "PRESIDENTE" && empleado.oficio != "DIRECTOR")
                {
                    filterContext.Result = GetRutaRedirect("Validacion", "ErrorAcceso");
                }

                //if (usuario.IsInRole("PRESIDENTE") == false && usuario.IsInRole("DIRECTOR") == false)
                //{
                //    filterContext.Result = GetRutaRedirect("Validacion", "ErrorAcceso");
                //}
            } else
            {
                filterContext.Result = GetRutaRedirect("Validacion", "Login");
            }
        }

        public RedirectToRouteResult GetRutaRedirect(String controlador, String accion)
        {
            RouteValueDictionary ruta = new RouteValueDictionary(new { controller = controlador, action = accion });
            RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
            return direccion;
        }
    }
}