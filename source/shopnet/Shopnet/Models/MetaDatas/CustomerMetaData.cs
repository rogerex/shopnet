using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shopnet.Models.MetaDatas
{
    public class CustomerMetaData
    {
        [Required]
        public string Name;

        [Required]
        [StringLength(24)]
        public string Phone;

        [Required]
        public string Address;

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        public string Email;
    }
}