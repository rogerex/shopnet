using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class ViewTypePayment : ViewStatus
    {
        public TypePayment TypePayment { get; set; }

        public ViewTypePayment(TypePayment typePayment)
        {
            this.Status = typePayment.Status;
        }

        public ViewTypePayment() {}

    }
}