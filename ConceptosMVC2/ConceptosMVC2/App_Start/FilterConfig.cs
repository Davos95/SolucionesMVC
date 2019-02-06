using ConceptosMVC2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.App_Start
{
    public class FilterConfig
    {
        //TENDRA UN METODO PARA REGISTRAR TODOS LOS FILTROS QUE UTILICEMOS EN NUESTRA APLICACION
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //REGISTRAMOS FILTROS PARA ATRIBUTOS DE EXCEPCION
            filters.Add(new HandleErrorAttribute());
            //REGISTRAMOS NUESTRO FILTRO DE EXCEPCION
            filters.Add(new HandleExceptionDoctorAttribute());
            filters.Add(new FilterMensajesLogAttribute());

        }
    }
}