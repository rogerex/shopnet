using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Controllers.Attributes;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class ControllerPermissionsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }

        public ControllerPermissionsViewModel()
        {
            Permissions = new List<PermissionViewModel>();
        }

        public void CreatePermissions(List<Role> roles, UserAccessAttribute userAccess) 
        {
            PermissionViewModel permission = new PermissionViewModel();
            permission.Name = userAccess.Title;
            permission.Description = userAccess.Description;
            if (userAccess.RestrictAccess)
                permission.RestrictAccess = "Warning: Take care with this permission";

            foreach (Role role in roles)
            {
                PermissionRoleViewModel permissionRole = new PermissionRoleViewModel();
                permissionRole.Role = role;
                permissionRole.Attribute = userAccess;
                permission.ItemChecklist.Add(permissionRole, role.Items.Where(i => i.Path == userAccess.Path).Any());
            }
            if (permission.ItemChecklist.Any())
                this.Permissions.Add(permission);
        }
    }
}