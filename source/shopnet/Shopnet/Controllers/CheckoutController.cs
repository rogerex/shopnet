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
        ShopnetEntities storeDB = new ShopnetEntities();

        //
        // GET: /Checkout/SalePayment

        public ActionResult SalePayment()
        {
            return View();
        }

        //
        // POST: /Checkout/SalePayment

        [HttpPost]
        public ActionResult SalePayment(FormCollection values)
        {
            var order = new Sale();
            TryUpdateModel(order);

            try
            {
                
                    order.UserID = 6;
                    order.Creation = DateTime.Now;

                    //Save Order
                    storeDB.Sales.AddObject(order);
                    storeDB.SaveChanges();

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateSale(order);

                    return RedirectToAction("Complete",
                        new { id = order.SaleID });
                

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Sales.Any(
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
