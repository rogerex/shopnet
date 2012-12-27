using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.ViewModels;

namespace Shopnet.Controllers
{
    public class RoleController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();
        
        //
        // GET: /Role/
        
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

        public ActionResult AddItem(Role role)      
        {
            IEnumerable<Item> myItems = db.Items.Where(i => i.Roles.Any(r => r.RoleID == role.RoleID));
            var model = new AssignItemsToRoleViewModel(role, myItems, db.Items.Include("ParentItem"));
            return View(model);
        }

        //
        // POST: /Role/AddItem/5

        [HttpPost]
        public ActionResult AddItem(int id_role, FormCollection postedForm)
        {
            List<Item> itemsToUpdate = new List<Item>();
            Role role = db.Roles.Include("Items").Single(r => r.RoleID == id_role);
            
            db.Roles.Attach(role);
            RemoveAllItems(role);

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

        private void RemoveAllItems(Role role)
        {
            foreach (var item in role.Items.ToList())
            {
                role.Items.Remove(item);
            }
            db.SaveChanges();
        }

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