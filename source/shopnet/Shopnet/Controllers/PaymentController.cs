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
    public class PaymentController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Payment/

        public ViewResult Index()
        {
            var payments = db.Payments.Include("Sale");
            return View(payments.ToList());
        }

        //
        // GET: /Payment/Details/5

        public ViewResult Details(int id)
        {
            Payment payment = db.Payments.Single(p => p.PaymentID == id);
            return View(payment);
        }

        //
        // GET: /Payment/Create

        public ActionResult Create()
        {
            ViewBag.SaleID = new SelectList(db.Sales, "SaleID", "SaleID");
            return View();
        } 

        //
        // POST: /Payment/Create

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.Creation = DateTime.Now;
                db.Payments.AddObject(payment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SaleID = new SelectList(db.Sales, "SaleID", "SaleID", payment.SaleID);
            return View(payment);
        }
        
        //
        // GET: /Payment/Edit/5
 
        public ActionResult Edit(int id)
        {
            Payment payment = db.Payments.Single(p => p.PaymentID == id);
            ViewBag.SaleID = new SelectList(db.Sales, "SaleID", "SaleID", payment.SaleID);
            return View(payment);
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Attach(payment);
                db.ObjectStateManager.ChangeObjectState(payment, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaleID = new SelectList(db.Sales, "SaleID", "SaleID", payment.SaleID);
            return View(payment);
        }

        //
        // GET: /Payment/Delete/5
 
        public ActionResult Delete(int id)
        {
            Payment payment = db.Payments.Single(p => p.PaymentID == id);
            return View(payment);
        }

        //
        // POST: /Payment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Payment payment = db.Payments.Single(p => p.PaymentID == id);
            db.Payments.DeleteObject(payment);
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