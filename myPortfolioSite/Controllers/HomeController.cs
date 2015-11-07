using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult StaticView(string viewName)
        {
            return View(viewName);
        }
    }
}