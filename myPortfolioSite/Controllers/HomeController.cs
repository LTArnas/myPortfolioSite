using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        // All entries must be lowercase, because we use .ToLower on the challenge string.
        List<string> whitelist = new List<string> {
            /* "about", */
            "contact",
            "knowledge",
            "skillset",
            "work",
            "education",
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