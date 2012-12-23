using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopnet.Models.Domain
{
    public class ShoppingCart
    {
        ShopnetEntities storeDB = new ShopnetEntities();

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartID";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product, decimal price)
        {
            // Get the matching cart and product instances
            var cartItem = storeDB.CartItems.SingleOrDefault(
                c => c.CartID == ShoppingCartId
                && c.ProductID == product.ProductID);
            
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    ProductID = product.ProductID,
                    CartID = ShoppingCartId,
                    Amount = 1,
                    Price = price,
                    Creation = DateTime.Now
                };

                storeDB.CartItems.AddObject(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Amount++;
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.CartItems.Single(
                cart => cart.CartID == ShoppingCartId
                && cart.CartItemID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    itemCount = cartItem.Amount;
                }
                else
                {
                    storeDB.CartItems.DeleteObject(cartItem);
                }

                // Save changes
                storeDB.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.CartItems.Where(cart => cart.CartID == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.CartItems.DeleteObject(cartItem);
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return storeDB.CartItems.Where(cartItem => cartItem.CartID == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.CartItems
                          where cartItems.CartID == ShoppingCartId
                          select (int?)cartItems.Amount).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply product price by count of that product to get 
            // the current price for each of those products in the cart
            // sum all product price totals to get the cart total
            decimal? total = (from cartItems in storeDB.CartItems
                              where cartItems.CartID == ShoppingCartId
                              select (int?)cartItems.Amount * cartItems.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateSale(Sale order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new DetailSale
                {
                    ProductID = item.ProductID,
                    SaleID = order.SaleID,
                    Price = item.Price,
                    Amount = item.Amount
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Amount * item.Price);

                storeDB.DetailSales.AddObject(orderDetail);

            }

            order.Creation = DateTime.Now;

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.SaleID;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.CartItems.Where(c => c.CartID == ShoppingCartId);

            foreach (CartItem item in shoppingCart)
            {
                item.CartID = userName;
            }
            storeDB.SaveChanges();
        }
    }
}