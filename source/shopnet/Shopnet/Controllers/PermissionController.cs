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
            PermissionsRolesViewModel permissionsRoles = new PermissionsRolesViewModel();
            permissionsRoles.Roles = db.Roles.ToList();
            permissionsRoles.controllersPermissions = GetControllersPermissions();
            permissionsRoles.controllersPermissions.OrderBy(p => p.Name);
            return View(permissionsRoles);
        }

        //
        // POST: /Permission/

        [HttpPost]
        public ActionResult Index(FormCollection postedForm)
        {
            List<Role> roles = db.Roles.Include("Items").ToList();
            foreach (Role role in roles)
            {
                foreach (var item in db.Items.ToList())
                {
                    if (postedForm[item.Path + "-" + role.RoleID] != null)
                    {
                        if (postedForm[item.Path + "-" + role.RoleID].ToString().Contains("true"))
                        {
                            if (!role.Items.Where(i => i.Path == item.Path).Any())
                            {
                                role.Items.Add(item);
                            }
                        }
                        else
                        {
                            if (role.Items.Where(i => i.Path == item.Path).Any())
                            {
                                role.Items.Remove(item);
                            }
                        }
                    }
                    else
                    {
                        db.DeleteObject(item);
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
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
                    controllerPermissions.Name = permissionController.Title;
                    controllerPermissions.Description = permissionController.Description;

                    foreach (MethodInfo method in controller.GetMethods())
                    { 
                        UserAccessAttribute userAccess = IsUserAccess(method);
                        if (userAccess != null)
                        {
                            userAccess.Path = "/" + controller.Name.Replace("Controller", "") + "/" + method.Name;
                            controllerPermissions.CreatePermissions(db.Roles.Include("Items").ToList(), userAccess);
                            if (!db.Items.Where(i => i.Path == userAccess.Path).Any())
                            {
                                Item item = new Item();
                                item.Name = userAccess.Title;
                                item.Description = userAccess.Description;
                                item.Path = userAccess.Path;
                                db.Items.AddObject(item);
                                db.SaveChanges();
                            }
                            else 
                            {
                                Item item = db.Items.Single(i => i.Path == userAccess.Path);
                                item.Name = userAccess.Title;
                                item.Description = userAccess.Description;
                                item.Path = userAccess.Path;
                                db.SaveChanges();
                            }
                        }
                    }
                    if (controllerPermissions.Permissions.Any())
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
