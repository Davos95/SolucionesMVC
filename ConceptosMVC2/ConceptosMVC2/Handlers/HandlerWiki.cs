using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ConceptosMVC2.Handlers
{
    public class HandlerWiki : IHttpHandler
    {
        public bool IsReusable { get; set; }

        private List<String> provincias;

        //Para ROUTERDATA NECESITAMOS REQUESTCONTEXT
        private RequestContext requestContext;

        public HandlerWiki(List<String> provincias, RequestContext requestcontext)
        {
            this.provincias = provincias;
            this.requestContext = requestcontext;
        }


        public void ProcessRequest(HttpContext context)
        {
            //ESTA CLASE ADMINISTRARA LA PETICION Y DECIDIRA DONDE NOS RECIRECCIONA (POR EJEMPLO, WIKIPEDIA)
            //String url = context.Request.RawUrl;
            //int barra = url.LastIndexOf("/") + 1;
            //String provincia = url.Substring(barra);

            //DICCIONARIO DE RUTAS
            RouteValueDictionary rutas = this.requestContext.RouteData.Values;
            
            //DE AQUI, YA PODEMOS RECUPERAR EL CONTROLLER, EL ACTION O LO QUE HAYAMOS ESCRITO EN NUESTRO MAPEO DE URL
            String provincia = rutas["nombreprovincia"].ToString();

            //EL SIGUIENTE PASO ES COMPROBAR QUE LA PROVINCIA NO ESTA EN LAS BLOQUEADAS
            if (this.provincias.Contains(provincia))
            {
                //LA FORMA DE INDICAR ERRORES EN MVC ES UTILIZANDO CONTEXTOS
                context.AddError(new Exception("La provincia "+ provincia + " no está permitida"));
            } else
            {
                String wiki = "https://es.wikipedia.org/wiki/" + provincia;
                context.Response.Redirect(wiki, true);
            }

            

        }
    }
}