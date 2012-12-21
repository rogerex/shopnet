using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopnet.Models
{
    public class StatusUser
    {
        public enum enumStatus
        {
            activate = 1,
            inactive = 2,
            requesting = 3,
            removed = 4
        }        

    }
}