using ConceptosMVC2.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConceptosMVC2
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "EliminarEnfermo",
            //    url: "Enfermos/Delete/{inscripcion}/{}",
            //    defaults: new {

            //        controller = "Enfermos",
            //        action = "EliminarEnfermo"
            //    },
            //    constraints: new { httpMethod = new HttpMethodConstraint("POST") });

            List<String> bloqueos = new List<String>();
            bloqueos.Add("Barcelona");
            bloqueos.Add("Madrid");

            RouteTable.Routes.Add("WikiProvincias", new Route("Provincias/Region/{nombreprovincia}", new RouteWiki(bloqueos)));

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
