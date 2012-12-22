using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Shopnet.Models.MetaDatas;

namespace Shopnet.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
}