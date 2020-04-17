using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ComplaintManagment.Helpers
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    //public class AuthorizationRequiredAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        var session = context.HttpContext.Session.GetString("waqar");
     
    //        Controller controller = context.Controller as Controller;

    //        if (controller != null)
    //        {
    //            if (session != null)
    //            {
    //                context.Result =
    //                       new RedirectToRouteResult(
    //                           new RouteValueDictionary{{ "controller", "Account" },
    //                                      { "action", "Login" }

    //                                                         });
    //            }
    //        }
    //        context.Result = new StatusCodeResult((int)HttpStatusCode.NotAcceptable);
    //        base.OnActionExecuting(context);
    //    }

    //}

    
}
