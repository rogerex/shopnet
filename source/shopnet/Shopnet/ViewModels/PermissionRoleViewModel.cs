using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopnet.Models;
using Shopnet.Controllers.Attributes;

namespace Shopnet.ViewModels
{
    public class PermissionRoleViewModel
    {
        public Role Role { get; set; }
        public UserAccessAttribute Attribute { get; set; }

        public string GetPermissionRoleID()
        {
            return Attribute.Path + "-" + Role.RoleID;
        }
    }
}
