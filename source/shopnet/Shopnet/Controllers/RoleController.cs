using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;

namespace Shopnet.Controllers
{
    public class RoleController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        public Role roleConcurrency = new Role();
        public Item itemElected = new Item();
        public IEnumerable<Item> itemsConcurrency;
        //
        // GET: /Role/
        //[Authorize(Roles = "Administrator")]
        //[CustomAuthorizeAttribute(RequiredRole = "Role")]
        //[Authorize]
        public ViewResult Index()
        {
            return View(db.Roles.ToList());
        }

        //
        // GET: /Role/Details/5

        public ViewResult Details(int id)
        {
            Role role = db.Roles.Single(r => r.RoleID == id);
            return View(role);
        }

        //
        // GET: /Role/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                role.Creation = DateTime.Now;
                db.Roles.AddObject(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        //
        // GET: /Role/Edit/5

        public ActionResult Edit(int id)
        {
            Role role = db.Roles.Single(r => r.RoleID == id);
            return View(role);
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Attach(role);
                db.ObjectStateManager.ChangeObjectState(role, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        //
        // GET: /Role/AddItem/5

        public ActionResult AddItem(Role role) //el id del rol        
        {
            IEnumerable<Item> myItems = db.Items.Where(i => i.Roles.Any(r => r.RoleID == role.RoleID));
            var model = new AssignItemsRoleViewModel(role, myItems, db.Items.Include("ParentItem"));
            return View(model);
        }
        [HttpPost]
        public ActionResult AddItem(int id_role, FormCollection postedForm)
        {
            //Include("NombrePropiedadNavegacion")
            List<Item> itemsToUpdate = new List<Item>();
            Role role = db.Roles.Include("Items").Single(r => r.RoleID == id_role);
            //Role role = db.Roles.Single(r => r.RoleID == id_role);           
            db.Roles.Attach(role);

            removeAll(role);

            foreach (var item in db.Items.ToList())
            {
                if (postedForm[item.Name].ToString().Contains("true"))
                {
                    role.Items.Add(item);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void removeAll(Role role)
        {
            foreach (var item in role.Items.ToList())
            {
                role.Items.Remove(item);
                //db.Items.DeleteObject(item);           
            }

            db.SaveChanges();
        }

        public void comparteSelecting(IEnumerable<Item> selects)
        {
            int cont = 0;
            foreach (Item item in itemsConcurrency)
            {
                if (item == selects.ElementAt(cont))
                {
                    item.Elected = true;
                    cont++;
                }
            }
        }



        //public string Add(Item elected)


        //
        // GET: /Role/Delete/5

        public ActionResult Delete(int id)
        {
            Role role = db.Roles.Single(r => r.RoleID == id);
            return View(role);
        }

        //
        // POST: /Role/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Single(r => r.RoleID == id);
            db.Roles.DeleteObject(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}