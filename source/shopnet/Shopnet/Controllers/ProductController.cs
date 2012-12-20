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
    public class ProductController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Product/

        public ViewResult Index()
        {
            return View(db.PRODUCTs.ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            PRODUCT product = db.PRODUCTs.Single(p => p.ID_PRODUCT == id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.AddObject(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            PRODUCT product = db.PRODUCTs.Single(p => p.ID_PRODUCT == id);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Attach(product);
                db.ObjectStateManager.ChangeObjectState(product, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            PRODUCT product = db.PRODUCTs.Single(p => p.ID_PRODUCT == id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PRODUCT product = db.PRODUCTs.Single(p => p.ID_PRODUCT == id);
            db.PRODUCTs.DeleteObject(product);
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