using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class SaleViewModel
    {
        public Sale Sale { get; set; }
        public List<DetailSale> Details { get; set; }
    }
}