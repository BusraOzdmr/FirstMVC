using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("hakkimdaRoute", "hakkimda", new { controller = "Home", action = "About" }, namespaces: new string[] { "FirstMVC.Controllers" });
            routes.MapRoute("projeRoute", "projelerim", new { controller = "Home", action = "Project" }, namespaces: new string[] { "FirstMVC.Controllers" });
            routes.MapRoute("iletisimRoute", "iletisim", new { controller = "Home", action = "Contact" }, namespaces: new string[] { "FirstMVC.Controllers" });
            routes.MapRoute("kvkkRoute", "kvkk", new { controller = "Home", action = "Kvkk" }, namespaces: new string[] { "FirstMVC.Controllers" });
            routes.MapRoute("privacyPolicyRoute", "privacyPolicy", new { controller = "Home", action = "PrivacyPolicy" }, namespaces: new string[] { "FirstMVC.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "FirstMVC.Controllers"}
            );
        }
    }
}
