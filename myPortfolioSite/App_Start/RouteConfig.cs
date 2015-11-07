using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace myPortfolioSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            // TODO: Add constraints, as right now it's a direct pass to Controller.View() so serves everything.
            routes.MapRoute(
                name: "Default",
                url: "{viewName}",
                defaults: new { controller = "Home", action = "StaticView", viewName = "Index" }
            );
        }
    }
}
