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
            routes.MapRoute("GetUser", "user/GetUser", new { controller = "User", action = "GetUser" });
            routes.MapRoute("GetUserByLogin", "user/GetUserByLogin", new { controller = "User", action = "GetUserByLogin" });
            routes.MapRoute("DeleteUser", "user/DeleteUser", new { controller = "User", action = "DeleteUser" });
            routes.MapRoute("MergeUser", "user/MergeUser", new { controller = "User", action = "MergeUser" });

            //ADMINUSERS
            routes.MapRoute("GetAdminUser", "adminuser/GetAdminUser", new { controller = "AdminUser", action = "GetAdminUser" });
            routes.MapRoute("GetAdminUserByLogin", "adminuser/GetdminUserByLogin", new { controller = "AdminUser", action = "GetAdminUserByLogin" });
            routes.MapRoute("DeleteAdminUser", "adminuser/DeleteAdminUser", new { controller = "AdminUser", action = "DeleteAdminUser" });
            routes.MapRoute("MergeAdminUser", "adminuser/MergeAdminUser", new { controller = "AdminUser", action = "MergeAdminUser" });

            //SUBJECTS
            routes.MapRoute("GetSubject", "subject/GetSubject", new { controller = "Subject", action = "GetSubject" });
            routes.MapRoute("DeleteSubject", "subject/DeleteSubject", new { controller = "Subject", action = "DeleteSubject" });
            routes.MapRoute("MergeUser", "subject/MergeUser", new { controller = "Subject", action = "MergeSubject" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
