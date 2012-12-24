using System.Collections.Generic;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}