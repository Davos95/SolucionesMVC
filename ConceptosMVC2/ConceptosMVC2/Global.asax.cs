using ConceptosMVC2.App_Start;
using ConceptosMVC2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConceptosMVC2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Application_Error()
        {
            //EXCEPCION GENERICA
            Exception ex = Server.GetLastError();
            //POR ESTAR EN ESTE METODO, LAS EXCEPCIONES DON HTTP
            HttpException exhttp = ex as HttpException;
            String action = "";
            if(exhttp.GetHttpCode() == 404)
            {
                action = "PaginaNoEncontrada";
            } else
            {
                action = "ErrorGeneral";
            }
            Context.ClearError();
            //CREAMOS LAS RUTAS PARA REDIRIGIR A NUESTRO CONTROLLER
            RouteData ruta = new RouteData();

            //AÑADIMOS A LA RUTALOS MAPS
            ruta.Values.Add("controller", "Error");
            ruta.Values.Add("action", action);
            IController controller;
            controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), ruta));

        }
    }
}
