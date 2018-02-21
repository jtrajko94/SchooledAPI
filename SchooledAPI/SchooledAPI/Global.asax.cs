using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchooledAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("PostTest", "ws/test", new { controller = "User", action = "TestPost" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
