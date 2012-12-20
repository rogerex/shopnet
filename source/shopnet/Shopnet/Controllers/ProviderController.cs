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
            return View(db.PROVIDERs.ToList());
        }

        //
        // GET: /Provider/Details/5

        public ViewResult Details(int id)
        {
            PROVIDER provider = db.PROVIDERs.Single(p => p.ID_PROVIDER == id);
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
        public ActionResult Create(PROVIDER provider)
        {
            if (ModelState.IsValid)
            {
                db.PROVIDERs.AddObject(provider);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(provider);
        }
        
        //
        // GET: /Provider/Edit/5
 
        public ActionResult Edit(int id)
        {
            PROVIDER provider = db.PROVIDERs.Single(p => p.ID_PROVIDER == id);
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(PROVIDER provider)
        {
            if (ModelState.IsValid)
            {
                db.PROVIDERs.Attach(provider);
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
            PROVIDER provider = db.PROVIDERs.Single(p => p.ID_PROVIDER == id);
            return View(provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PROVIDER provider = db.PROVIDERs.Single(p => p.ID_PROVIDER == id);
            db.PROVIDERs.DeleteObject(provider);
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