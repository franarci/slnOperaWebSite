using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace OperaWebSite.Filter
{
    public class MyFilterAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //me va a retornar la ruta del controlador solicitado
            //controller/action
            //{controller}/{action}

            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine(controller + " Action: " + action + " Paso por OnActionExecuting");

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine(controller + " Action: " + action + " Paso por OnActionExecuting");
            base.OnActionExecuted(filterContext);
        }
    }
}