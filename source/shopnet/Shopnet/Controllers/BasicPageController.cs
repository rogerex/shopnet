using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;

namespace Shopnet.Controllers
{
    public class BasicPageController : Controller
    {
        public virtual ILogger Logger { get; set; }

        //
        // GET: /BasicPage/

        public ActionResult Index()
        {
            Logger.WarnFormat("Se ingreso");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
