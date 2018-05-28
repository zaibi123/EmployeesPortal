using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace computan.lawpreviewforms.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var areaName = filterContext.RouteData.DataTokens["area"];
            if (areaName.Equals("admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "Login", area = "admin" }));
            }
            else if (areaName.Equals("lawfirm"))
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "Login", area = "lawfirm" }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }

            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    base.HandleUnauthorizedRequest(filterContext);
            //}
            //else
            //{
                
            //    // other conditions...

            //}
        }
    }
}