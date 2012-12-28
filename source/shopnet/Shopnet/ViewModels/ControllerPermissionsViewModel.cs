using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Controllers.Attributes;

namespace Shopnet.ViewModels
{
    public class ControllerPermissionsViewModel
    {
        public PermissionAttribute Attribute { get; set; }
        public Dictionary<UserAccessAttribute, bool> ItemChecklist { get; set; }

        public ControllerPermissionsViewModel()
        {
            ItemChecklist = new Dictionary<UserAccessAttribute, bool>();
        }
    }
}