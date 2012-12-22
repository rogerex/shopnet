using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shopnet.Models.MetaDatas
{
    public class ProductMetaData
    {
        [Required]
        public string Code;

        [Required]
        public string Name;
    }
}