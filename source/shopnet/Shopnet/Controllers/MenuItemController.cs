using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.ViewModels;
namespace Shopnet.Controllers
{
    public class MenuItemController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /MenuItem/
        
        [ChildActionOnly]
        public ActionResult ItemList()
        {            
            int id = ((Session)HttpContext.Session["Session"]).UserID;
            User user = db.Users.Include("Roles").Single(u => u.UserID == id);
            IEnumerable<Role> roles = user.Roles;         
            List<MenuItemViewModel> items = new List<MenuItemViewModel>();
            foreach (Role role in roles)
            {
                Role currentRole = db.Roles.Include("Items").Single(r => r.RoleID == role.RoleID);
                foreach (Item item in currentRole.Items)
                {
                    items.Add(new MenuItemViewModel { Name = item.Name, Controller = item.Path, Action = "" });
                }
            }
            return PartialView("ItemList", items);
        }
    }
}