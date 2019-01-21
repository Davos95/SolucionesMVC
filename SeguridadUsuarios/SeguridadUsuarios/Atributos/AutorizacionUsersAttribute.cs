using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeguridadUsuarios.Atributos
{
    public class AutorizacionUsersAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //PREGUNTAMOS SI EL USUARIO ESTÁ AUTENTICADO
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //SI NO ONS IMPORTA EL ROLE DEL USUARIO, O SU NAME...
                //AQUI NO HACEMOS NADA...
                //COMO QUEREMOS VALIDAR POR EL ROLE DEL USUARIO...
                //EN UN PRINCIPAL, HAY UN METODO QUE ES IsInRole("ROLE")
                if (filterContext.HttpContext.User.IsInRole("ADMINISTRADOR") == false)
                {
                    //LE ENVIAREMOS A ERRORACCESO
                    //LA CLASE RouteValueDirectory PERMITE CREAR UNA RUTA CON ACTION Y CONTROLLER
                    RouteValueDictionary ruta = new RouteValueDictionary(new { Controller = "Validacion", Action = "ErrorAcceso" });
                    //UNA VEZ QUE TENEMOS LA RUTA DONDE DESEAMOS REDIRIGIR AL USUARIO, PARA PODER HACERLA EFECTIVA SE HACE CON LA CLASE RedirectToReouteResult
                    RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
                    //REDDIRECIONAMOS LA PETICION A LA RUTA
                    filterContext.Result = direccion;
                }
                
            } else
            {
                //AQUI LLEVAMOS AL USUARIO A LOGIN
                RouteValueDictionary ruta = new RouteValueDictionary(new { Controller = "Validacion", Action = "Login" });
                RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
                filterContext.Result = direccion;
            }
        }
    }
}