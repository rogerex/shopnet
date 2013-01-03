using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.Models.Domain;
using Shopnet.Controllers.Attributes;

namespace Shopnet.Controllers
{
    [Permission(Title = "Product", Description = "Product Controller")]
    public class ProductController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Product/

        [UserAccess(Title = "Product List", Description = "Access to Product List")]
        public ViewResult Index()
        {
            return View(db.Products.ToList());
        }

        //
        // GET: /Product/Details/5

        [UserAccess(Title = "Product Details", Description = "Access to Product Details")]
        public ViewResult Details(int id)
        {
            Product product = db.Products.Single(p => p.ProductID == id);
            return View(product);
        }

        //
        // GET: /Product/Create

        [UserAccess(Title = "Product Create", Description = "Access to Product Create")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Creation = DateTime.Now;
                db.Products.AddObject(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /Product/Edit/5

        [UserAccess(Title = "Product Edit", Description = "Access to Product Edit")]
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Single(p => p.ProductID == id);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Attach(product);
                db.ObjectStateManager.ChangeObjectState(product, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        [UserAccess(Title = "Product Details", Description = "Access to Product Delete", RestrictAccess = true)]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Single(p => p.ProductID == id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Single(p => p.ProductID == id);
            db.Products.DeleteObject(product);
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