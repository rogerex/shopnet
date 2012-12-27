using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Shopnet.Models.MetaDatas;

namespace Shopnet.Models
{
    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        public bool Elected { get; set; }

        public int Index { get; set; }
    }

}