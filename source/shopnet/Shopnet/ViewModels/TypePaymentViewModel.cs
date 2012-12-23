using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopnet.Models;

namespace Shopnet.ViewModels
{
    public class TypePaymentViewModel : StatusViewModel
    {
        public TypePayment TypePayment { get; set; }

        public TypePaymentViewModel(TypePayment typePayment)
        {
            this.TypePayment = typePayment;
            this.Status = typePayment.Status;
        }

        public TypePaymentViewModel() {}

    }
}