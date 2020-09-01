using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Blog", // default controller
                    action = "Index",  // default action on the controller
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "BlogView",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Blog", //blog Controller
                    action = "BlogView",
                    id = UrlParameter.Optional
                }
            );

        }
    }
}
