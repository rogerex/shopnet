using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;

namespace Shopnet.Controllers.Attributes
{
    public class UserAccessAttribute : AuthorizeAttribute
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool RestrictAccess { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            AccountController account = new AccountController();
            if (account.IsLogOn())
            {
                // User user = account.getUser();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        {"controller", "BasicPage"},
                        {"action", "AccessDenied"}
                });
            }
 
        }
    }
}