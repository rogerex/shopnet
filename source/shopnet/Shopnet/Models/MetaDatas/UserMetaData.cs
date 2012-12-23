using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shopnet.Models.MetaDatas
{
    public class UserMetaData
    {
        [Required]
        public string Name;

        [Required]
        public string Password;

        [Required]
        public string Email;

        [Required]
        public int Status;
    }
}