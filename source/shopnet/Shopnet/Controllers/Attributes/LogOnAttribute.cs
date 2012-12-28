using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Shopnet.Models;
using System.Web;
using System.Web.Routing;

namespace Shopnet.Controllers
{
    public class LogOnAttribute : AuthorizeAttribute
    {
        public bool Status { get; set; } 

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Session session = (Session)HttpContext.Current.Session["Session"];
            if (session == null && Status)
            {
                AccessDenied(filterContext);
            }
            else 
            {
                if (session != null && !Status)
                {
                    Home(filterContext);
                }
            }
        }

        private void AccessDenied(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary {
                        {"controller", "BasicPage"},
                        {"action", "AccessDenied"}
            });
        }

        private void Home(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary {
                        {"controller", "BasicPage"},
                        {"action", "Index"}
            });
        }
    }
}
