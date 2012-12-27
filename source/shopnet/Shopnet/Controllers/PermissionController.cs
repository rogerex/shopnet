using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Shopnet.Controllers.Attributes;

namespace Shopnet.Controllers
{
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/

        public ActionResult Index()
        {
            List<string> actions = new List<string>();
            string[] controllers = {"AccountController"};
            foreach (string controller in controllers)
            {
                if (true)
                {
                    foreach (MethodInfo method in (typeof(AccountController)).GetMethods())
                    { 
                        if (IsUserAccess(method))
                        {
                            actions.Add(method.Name);
                        }
                        actions.Add(method.Name);
                    }
                }
            }
            return View(actions);
        }

        private bool IsUserAccess(MemberInfo member)
        {
            foreach (object attribute in member.GetCustomAttributes(typeof(AccountController), false))
            {
                if (attribute is UserAccessAttribute)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
