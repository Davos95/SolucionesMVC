using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC2.Filters
{
    public class FilterMensajesLogAttribute: ActionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("Action OnActionExecuting: " + accion + " fecha: " + DateTime.Now);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("Action OnActionExecuted: " + accion + " fecha: " + DateTime.Now);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("Action OnResultExecuting: " + accion + " fecha: " + DateTime.Now);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("Action OnResultExecuted: " + accion + " fecha: " + DateTime.Now);
        }
        
    }

}