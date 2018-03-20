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

            //USERS
            routes.MapRoute("GetUserById", "user/GetUserById", new { controller = "User", action = "GetUserById" });
            routes.MapRoute("GetUserByLogin", "user/GetUserByLogin", new { controller = "User", action = "GetUserByLogin" });
            routes.MapRoute("DeleteUser", "user/DeleteUser", new { controller = "Users", action = "DeleteUser" });
            routes.MapRoute("MergeUser", "user/MergeUser", new { controller = "Users", action = "MergeUser" });

            //ADMINUSERS
            routes.MapRoute("GetAdminUserById", "adminuser/GetAdminUserById", new { controller = "AdminUser", action = "GetAdminUserById" });
            routes.MapRoute("GetAdminUserByLogin", "adminuser/GetdminUserByLogin", new { controller = "AdminUser", action = "GetAdminUserByLogin" });
            routes.MapRoute("DeleteAdminUser", "adminuser/DeleteAdminUser", new { controller = "AdminUsers", action = "DeleteAdminUser" });
            routes.MapRoute("MergeAdminUser", "adminuser/MergeAdminUser", new { controller = "AdminUsers", action = "MergeAdminUser" });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
