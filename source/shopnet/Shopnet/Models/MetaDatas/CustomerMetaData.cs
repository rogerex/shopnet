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
        public string Phone;

        [Required]
        public string Address;

        [Required]
        public string Email;
    }
}