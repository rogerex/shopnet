using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;

namespace Shopnet.Models
{ 
    public class PurchaseController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Purchase/

        public ViewResult Index()
        {
            var purchases = db.Purchases.Include("Provider").Include("User");
            return View(purchases.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ViewResult Details(int id)
        {
            Purchase purchase = db.Purchases.Single(p => p.PurchaseID == id);
            return View(purchase);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        } 

        //
        // POST: /Purchase/Create

        [HttpPost]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.AddObject(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "Name", purchase.ProviderID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", purchase.UserID);
            return View(purchase);
        }
        
        //
        // GET: /Purchase/Edit/5
 
        public ActionResult Edit(int id)
        {
            Purchase purchase = db.Purchases.Single(p => p.PurchaseID == id);
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "Name", purchase.ProviderID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", purchase.UserID);
            return View(purchase);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Attach(purchase);
                db.ObjectStateManager.ChangeObjectState(purchase, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "Name", purchase.ProviderID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", purchase.UserID);
            return View(purchase);
        }

        //
        // GET: /Purchase/Delete/5
 
        public ActionResult Delete(int id)
        {
            Purchase purchase = db.Purchases.Single(p => p.PurchaseID == id);
            return View(purchase);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Purchase purchase = db.Purchases.Single(p => p.PurchaseID == id);
            db.Purchases.DeleteObject(purchase);
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