using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopnet.ViewModels
{
    public class PermissionViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RestrictAccess { get; set; }
        public Dictionary<PermissionRoleViewModel, bool> ItemChecklist { get; set; }

        public PermissionViewModel() 
        {
            ItemChecklist = new Dictionary<PermissionRoleViewModel, bool>();
        }
    }
}
