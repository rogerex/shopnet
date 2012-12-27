using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Shopnet.Models;
namespace Shopnet.ViewModels
{
    public class AssignRolesToUserViewModel
    {
        public Dictionary<Role, bool> RoleChecklist { get; set; }
        public User userCocurrency { get; set; }
      
        public AssignRolesToUserViewModel(User user, IEnumerable myRoles, IEnumerable roles)
        {
            bool found;
            RoleChecklist = new Dictionary<Role, bool>();
            this.userCocurrency = user;
            foreach (Role role in roles)
            {
                found = false;
                foreach (Role myRole in myRoles)
                {
                    if (myRole.RoleID == role.RoleID)
                    {
                        RoleChecklist.Add(myRole, true);
                        found = true;
                        break;
                    }
                }
                if (!found)
                    RoleChecklist.Add(role, false);
            }
        }
    }
}