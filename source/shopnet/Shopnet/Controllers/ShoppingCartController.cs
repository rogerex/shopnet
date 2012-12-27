using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;
using Shopnet.Models.Domain;
using Shopnet.ViewModels;

namespace Shopnet.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShopnetEntities db = new ShopnetEntities();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /ShoppingCart/AddToCart/5/10.0

        public ActionResult AddToCart(int id, decimal price)
        {
            // Retrieve the product from the database
            Product addedProduct = db.Products
                .Single(product => product.ProductID == id);

            if (addedProduct.Price <= price)
            {
                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.AddToCart(addedProduct, price);
            }
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the product to display confirmation
            CartItem cartItem = db.CartItems.Include("Product")
                .Single(item => item.CartItemID == id);

            string productName = cartItem.Product.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteID = id
            };

            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

        //
        // AJAX: /ShoppingCart/Products/Code

        [HttpPost]
        public ActionResult Products(string key)
        {
            if (String.IsNullOrEmpty(key))
                return RedirectToAction("Index");
            List<Product> products = db.Products.Where(product => product.Code.Contains(key)).Take(5).ToList();
            return View(products);
        }
    }
}
