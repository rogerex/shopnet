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
        //
        // GET: /MenuItem/
        private ShopnetEntities db = new ShopnetEntities();
        [ChildActionOnly]
        public ActionResult ItemList()
        {            
            int id = ((Session)Session["Session"]).UserID;
            User user = db.Users.Include("Roles").Single(u => u.UserID == id);
            IEnumerable<Role> roles = user.Roles;         
            List<ViewModelItemMenu> items = new List<ViewModelItemMenu>();
            foreach (var role in roles)
            {
                items.Add(new ViewModelItemMenu { name = role.Name, control = role.Name, action = role.Name });
            }

            //  return View(items);
            return PartialView("ItemList", items);
        }

    }
}