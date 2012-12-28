using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Shopnet.Controllers.Attributes;
using Shopnet.ViewModels;
using Shopnet.Models;

namespace Shopnet.Controllers
{
    public class PermissionController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Permission/

        public ActionResult Index()
        {
            List<RolePermissionsViewModel> rolesPermissions = new List<RolePermissionsViewModel>();

            List<Role> roles = db.Roles.ToList();
            foreach (Role role in roles)
            {
                RolePermissionsViewModel rolePermissions = new RolePermissionsViewModel();
                rolePermissions.Role = role;
                rolePermissions.Controllers.AddRange(GetControllersPermissions());

                rolesPermissions.Add(rolePermissions);
            }
            return View(rolesPermissions);
        }

        private List<ControllerPermissionsViewModel> GetControllersPermissions()
        {
            List<ControllerPermissionsViewModel> controllersPermissions = new List<ControllerPermissionsViewModel>();
            
            List<Type> controllers = GetControllers();

            foreach (Type controller in controllers)
            {
                PermissionAttribute permissionController = IsPermissionController(controller);
                if (permissionController != null)
                {
                    ControllerPermissionsViewModel controllerPermissions = new ControllerPermissionsViewModel();
                    controllerPermissions.Attribute = permissionController;

                    foreach (MethodInfo method in controller.GetMethods())
                    { 
                        UserAccessAttribute userAccess = IsUserAccess(method);
                        if (userAccess != null)
                        {
                            // methods.Add(controller.Name.Replace("Controller", "") + "/" + method.Name);
                            // controllerPermissions.Controllers.Add(controllerPermissions);
                            controllerPermissions.ItemChecklist.Add(userAccess, true);
                        }
                    }
                    if (controllerPermissions.ItemChecklist.Any())
                        controllersPermissions.Add(controllerPermissions);
                }
            }
            return controllersPermissions;
        }

        private PermissionAttribute IsPermissionController(Type type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is PermissionAttribute)
                {
                    return (PermissionAttribute)attribute;
                }
            }
            return null;
        }

        private UserAccessAttribute IsUserAccess(MethodInfo member)
        {
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                if (attribute is UserAccessAttribute)
                {
                    return (UserAccessAttribute)attribute;
                }
            }
            return null;
        }

        private List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        private List<string> GetControllerNames()
        {
            List<string> controllerNames = new List<string>();
            GetSubClasses<Controller>().ForEach(
                type => controllerNames.Add(type.Name));
            return controllerNames;
        }

        private List<Type> GetControllers()
        {
            List<Type> controllers = new List<Type>();
            GetSubClasses<Controller>().ForEach(
                type => controllers.Add(type));
            return controllers;
        }

    }
}
