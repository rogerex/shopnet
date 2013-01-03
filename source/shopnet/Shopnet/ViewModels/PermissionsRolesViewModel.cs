using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class PermissionsRolesViewModel
    {
        public List<Role> Roles { get; set; }
        public List<ControllerPermissionsViewModel> controllersPermissions { get; set; }
    }
}
