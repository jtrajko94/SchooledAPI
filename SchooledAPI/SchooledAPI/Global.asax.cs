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
            routes.MapRoute("GetUser", "user/getuser", new { controller = "User", action = "GetUser" });
            routes.MapRoute("GetUserByLogin", "user/getuserbylogin", new { controller = "User", action = "GetUserByLogin" });
            routes.MapRoute("DeleteUser", "user/deleteuser", new { controller = "User", action = "DeleteUser" });
            routes.MapRoute("MergeUser", "user/mergeuser", new { controller = "User", action = "MergeUser" });

            //ADMINUSERS
            routes.MapRoute("GetAdminUser", "adminuser/getadminuser", new { controller = "AdminUser", action = "GetAdminUser" });
            routes.MapRoute("GetAdminUserByLogin", "adminuser/getadminuserbylogin", new { controller = "AdminUser", action = "GetAdminUserByLogin" });
            routes.MapRoute("DeleteAdminUser", "adminuser/deleteadminuser", new { controller = "AdminUser", action = "DeleteAdminUser" });
            routes.MapRoute("MergeAdminUser", "adminuser/mergeadminuser", new { controller = "AdminUser", action = "MergeAdminUser" });

            //SUBJECTS
            routes.MapRoute("GetSubject", "subject/getsubject", new { controller = "Subject", action = "GetSubject" });
            routes.MapRoute("DeleteSubject", "subject/deletesubject", new { controller = "Subject", action = "DeleteSubject" });
            routes.MapRoute("MergeUser", "subject/mergeuser", new { controller = "Subject", action = "MergeSubject" });

            //COURSES
            routes.MapRoute("GetCourse", "course/getcourse", new { controller = "Course", action = "GetCourse" });
            routes.MapRoute("DeleteCourse", "course/deletecourse", new { controller = "Course", action = "DeleteCourse" });
            routes.MapRoute("MergeCourse", "course/mergecourse", new { controller = "Course", action = "MergeCourse" });
            routes.MapRoute("GetSubjectCourses", "course/getsubjectcourses", new { controller = "Course", action = "GetSubjectCourses" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
