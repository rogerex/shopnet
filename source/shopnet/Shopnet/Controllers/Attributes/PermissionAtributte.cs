using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopnet.Controllers.Attributes
{
    public class PermissionAtributte : Attribute
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}