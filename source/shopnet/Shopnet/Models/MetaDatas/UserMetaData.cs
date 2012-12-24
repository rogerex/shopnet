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
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        public string Email;

        [Required]
        public int Status;
    }
}