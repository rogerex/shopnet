using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.Models.Domain;

namespace Shopnet.Controllers
{
    public class CheckoutController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /Checkout/SalePayment

        public ActionResult SalePayment()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewBag.Total = cart.GetTotal();
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        //
        // POST: /Checkout/SalePayment

        [HttpPost]
        public ActionResult SalePayment(FormCollection values)
        {
            Sale order = new Sale();
            TryUpdateModel(order);

            try
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);

                order.UserID = 6;
                order.Creation = DateTime.Now;
                order.Total = cart.GetTotal();
                
                //Save Order
                db.Sales.AddObject(order);
                db.SaveChanges();

                //Process the order
                cart.CreateSale(order);

                return RedirectToAction("Complete", new { id = order.SaleID });
            }
            catch
            {
                //Invalid - redisplay with errors
                var cart = ShoppingCart.GetCart(this.HttpContext);

                ViewBag.Total = cart.GetTotal();
                ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
                ViewBag.TypePaymentID = new SelectList(db.TypePayments, "TypePaymentID", "Name", order.TypePaymentID);
                ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", order.UserID);
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Sales.Any(
                o => o.SaleID == id &&
                o.UserID == 6);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
