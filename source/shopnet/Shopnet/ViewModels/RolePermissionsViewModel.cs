using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class RolePermissionsViewModel
    {
        public Role Role { get; set; }
        public List<ControllerPermissionsViewModel> Controllers { get; set; }

        public RolePermissionsViewModel() 
        {
            this.Controllers = new List<ControllerPermissionsViewModel>();
        }
    }
}