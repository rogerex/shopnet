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
    public class TypePaymentController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /TypePayment/

        public ViewResult Index()
        {
            return View(db.TypePayments.ToList());
        }

        //
        // GET: /TypePayment/Details/5

        public ViewResult Details(int id)
        {
            TypePayment typepayment = db.TypePayments.Single(t => t.TypePaymentID == id);
            return View(typepayment);
        }

        //
        // GET: /TypePayment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TypePayment/Create

        [HttpPost]
        public ActionResult Create(TypePayment typepayment)
        {
            if (ModelState.IsValid)
            {
                db.TypePayments.AddObject(typepayment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(typepayment);
        }
        
        //
        // GET: /TypePayment/Edit/5
 
        public ActionResult Edit(int id)
        {
            TypePayment typepayment = db.TypePayments.Single(t => t.TypePaymentID == id);
            return View(typepayment);
        }

        //
        // POST: /TypePayment/Edit/5

        [HttpPost]
        public ActionResult Edit(TypePayment typepayment)
        {
            if (ModelState.IsValid)
            {
                db.TypePayments.Attach(typepayment);
                db.ObjectStateManager.ChangeObjectState(typepayment, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typepayment);
        }

        //
        // GET: /TypePayment/Delete/5
 
        public ActionResult Delete(int id)
        {
            TypePayment typepayment = db.TypePayments.Single(t => t.TypePaymentID == id);
            return View(typepayment);
        }

        //
        // POST: /TypePayment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TypePayment typepayment = db.TypePayments.Single(t => t.TypePaymentID == id);
            db.TypePayments.DeleteObject(typepayment);
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