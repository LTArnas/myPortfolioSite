using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        List<string> whitelist = new List<string> {
            /* "about", */
            "contact",
            "knowledge",
            "Skillset",
            "Work",
            "Education",
            "index",
            "projects" };

        // GET: Home
        public ActionResult StaticView(string viewName)
        {
            string viewNameRequest = "Index";
            viewName = viewName.ToLower();

            if (whitelist.Contains(viewName))
                viewNameRequest = viewName;

            return View(viewNameRequest);
        }
    }
}