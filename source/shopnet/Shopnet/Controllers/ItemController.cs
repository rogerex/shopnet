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
    public class ItemController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Item/

        public ViewResult Index()
        {
            var items = db.Items.Include("ParentItem");
            return View(items.ToList());
        }

        //
        // GET: /Item/Details/5

        public ViewResult Details(int id)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            ViewBag.ParentItemID = new SelectList(db.Items, "ItemID", "Description");
            return View();
        } 

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.AddObject(item);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ParentItemID = new SelectList(db.Items, "ItemID", "Description", item.ParentItemID);
            return View(item);
        }
        
        //
        // GET: /Item/Edit/5
 
        public ActionResult Edit(int id)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            ViewBag.ParentItemID = new SelectList(db.Items, "ItemID", "Description", item.ParentItemID);
            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Attach(item);
                db.ObjectStateManager.ChangeObjectState(item, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentItemID = new SelectList(db.Items, "ItemID", "Description", item.ParentItemID);
            return View(item);
        }

        //
        // GET: /Item/Delete/5
 
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Item item = db.Items.Single(i => i.ItemID == id);
            db.Items.DeleteObject(item);
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