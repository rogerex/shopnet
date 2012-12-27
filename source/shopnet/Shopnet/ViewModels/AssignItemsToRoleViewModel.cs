using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Shopnet.Models;

namespace Shopnet.ViewModels
{    
    public class AssignItemsToRoleViewModel
    {
        public Dictionary<Item, bool> ItemChecklist { get; set; }
        
        public Role RoleCocurrency { get; set; }

        public AssignItemsToRoleViewModel(Role role)
        {
            this.RoleCocurrency = role;
        }

        public AssignItemsToRoleViewModel(Role role,IEnumerable myItems , IEnumerable items) 
        {
            bool found;            
            ItemChecklist = new Dictionary<Item, bool>();
            this.RoleCocurrency = role;
            foreach(Item item in items)
            {
                found = false;
                foreach (Item myItem in myItems)
                {
                    if (myItem.ItemID == item.ItemID)
                    {
                        ItemChecklist.Add(myItem, true);
                        found = true;
                        break;
                    }                    
                }
                if (!found)
                    ItemChecklist.Add(item,false);
            }
        }
    }
}