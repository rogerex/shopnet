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
    public class ProviderController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Provider/

        public ViewResult Index()
        {
            return View(db.Providers.ToList());
        }

        //
        // GET: /Provider/Details/5

        public ViewResult Details(int id)
        {
            Provider provider = db.Providers.Single(p => p.ProviderID == id);
            return View(provider);
        }

        //
        // GET: /Provider/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Provider/Create

        [HttpPost]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                provider.Creation = DateTime.Now;
                db.Providers.AddObject(provider);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(provider);
        }
        
        //
        // GET: /Provider/Edit/5
 
        public ActionResult Edit(int id)
        {
            Provider provider = db.Providers.Single(p => p.ProviderID == id);
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Attach(provider);
                db.ObjectStateManager.ChangeObjectState(provider, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        //
        // GET: /Provider/Delete/5
 
        public ActionResult Delete(int id)
        {
            Provider provider = db.Providers.Single(p => p.ProviderID == id);
            return View(provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Provider provider = db.Providers.Single(p => p.ProviderID == id);
            db.Providers.DeleteObject(provider);
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