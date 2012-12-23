using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopnet.ViewModels
{
    public class ViewStatus
    {
        public int Status { get; set; }
 
        public String StatusName
        {
            get
            {
                var array = GetStatus().ToArray();
                var items = from value in array where value.Value == this.Status + "" select value;
                return items.Any() ? items.First<SelectListItem>().Text : "Undefined";
            }
        }

        public List<SelectListItem> GetStatus()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            status.Add(new SelectListItem() { Text = "Active", Value = "1" });
            status.Add(new SelectListItem() { Text = "Inactive", Value = "0" });

            return status;
        }
    }
}