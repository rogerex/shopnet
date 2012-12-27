using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Shopnet.Models;

namespace Shopnet.Controllers.Attributes
{
    public class UserAccessAttribute : AuthorizeAttribute
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool RestrictAccess { get; set; }

        private ShopnetEntities db = new ShopnetEntities();

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Session session = (Session)HttpContext.Current.Session["Session"];
            if (session != null)
            {
                User user = db.Users.Include("Roles").Single(m => m.UserID == session.UserID);
                if (user.Roles.Any())
                {
                    var request = HttpContext.Current.Request;
                    string path = request.FilePath;
                    bool res = false;
                    foreach (Role role in user.Roles)
                    {
                        Role rol = db.Roles.Include("Items").Single(r => r.RoleID == role.RoleID);
                        var rows = from value in rol.Items where value.Path == path select value;
                        if (rows.Any())
                            res = true;
                    }
                    if (!res)
                        AccessDenied(filterContext);
                }
                else
                {
                    AccessDenied(filterContext);
                }
            }
            else
            {
                AccessDenied(filterContext);
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
    }
}