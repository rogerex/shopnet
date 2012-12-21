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
    public class SaleController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Sale/

        public ViewResult Index()
        {
            var sales = db.Sales.Include("Customer").Include("TypePayment").Include("User");
            return View(sales.ToList());
        }

        //
        // GET: /Sale/Details/5

        public ViewResult Details(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleID == id);
            return View(sale);
        }

        //
        // GET: /Sale/Create

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Description");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        } 

        //
        // POST: /Sale/Create

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                sale.Creation = DateTime.Now;
                db.Sales.AddObject(sale);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", sale.CustomerID);
            ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Description", sale.TypePaymentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", sale.UserID);
            return View(sale);
        }
        
        //
        // GET: /Sale/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleID == id);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", sale.CustomerID);
            ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Description", sale.TypePaymentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", sale.UserID);
            return View(sale);
        }

        //
        // POST: /Sale/Edit/5

        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Attach(sale);
                db.ObjectStateManager.ChangeObjectState(sale, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", sale.CustomerID);
            ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Description", sale.TypePaymentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", sale.UserID);
            return View(sale);
        }

        //
        // GET: /Sale/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleID == id);
            return View(sale);
        }

        //
        // POST: /Sale/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Sale sale = db.Sales.Single(s => s.SaleID == id);
            db.Sales.DeleteObject(sale);
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