using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Shopnet.Models;
namespace Shopnet.Models
{    
    public class AssignItemsRoleViewModel
    {
        public Dictionary<Item, bool> ItemChecklist { get; set; }
        public Role roleCocurrency { get; set; }
        public AssignItemsRoleViewModel(Role role)
        {
            this.roleCocurrency = role;
        }
        public AssignItemsRoleViewModel(Role role,IEnumerable myItems , IEnumerable items) 
        {
            bool found;            
            ItemChecklist = new Dictionary<Item,bool>();
            this.roleCocurrency = role;
           foreach(Item item in  items)
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