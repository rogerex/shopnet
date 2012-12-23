using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace Shopnet.Models.MetaDatas
{
    public class TypePaymentMetaData
    {
        [Required]
        public string Name;

        [Required]
        public int Status;
    }
}