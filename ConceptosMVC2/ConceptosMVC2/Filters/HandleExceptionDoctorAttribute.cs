using ConceptosMVC2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConceptosMVC2.Filters
{
    public class HandleExceptionDoctorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            
            if(filterContext.ExceptionHandled == false)
            {
                String mensaje = filterContext.Exception.Message;
                String controlador = filterContext.RouteData.Values["controller"].ToString();
                RepositoryHospital repo = new RepositoryHospital();
                repo.InsertarExcepcion(mensaje, controlador, DateTime.Now);
                //MANEJAMOS LA EXCEPCION
                filterContext.ExceptionHandled = true;

                //En algun momento nos llevaremos los datos a una vista de errores en doctor
                RouteValueDictionary rutaerror = new RouteValueDictionary( new  {
                    controller = "Doctores", action = "ErrorSalarios"
                });
                RedirectToRouteResult direccion = new RedirectToRouteResult(rutaerror);
                filterContext.Result = direccion;
            }
        }
    }
}