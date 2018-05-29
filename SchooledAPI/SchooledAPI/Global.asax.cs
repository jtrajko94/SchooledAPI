using SchooledAPI.Utilities;
using System.Web.Http;
using System.Web.Routing;

namespace SchooledAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            //TODO on these, MAPHTTPROUTE, controller/action, Change controller to API Controller, Change return types, remove static from action methods, Data ids should be guids

            //APIKeyService
            routes.MapHttpRoute("GetAPIKey", "apikey/get", new { controller = "APIKey", action = "Get" });
            routes.MapHttpRoute("CreateAPIKey", "apikey/create", new { controller = "APIKey", action = "Create" });

            //SCHOOLS
            routes.MapHttpRoute("GetSchool", "school/get", new { controller = "School", action = "Get" });
            routes.MapHttpRoute("MergeSchool", "school/merge", new { controller = "School", action = "Merge" });
            routes.MapHttpRoute("SearchSchool", "school/search", new { controller = "School", action = "Search" });
            routes.MapHttpRoute("GetSchoolType", "school/getschooltype", new { controller = "School", action = "GetSchoolType" });

            //USERS
            routes.MapHttpRoute("GetUser", "user/get", new { controller = "User", action = "Get" });
            routes.MapHttpRoute("GetUserByLogin", "user/getbylogin", new { controller = "User", action = "GetByLogin" });
            routes.MapHttpRoute("GetUserByEmail", "user/getbyemail", new { controller = "User", action = "GetByEmail" });
            routes.MapHttpRoute("MergeUser", "user/merge", new { controller = "User", action = "Merge" });
            routes.MapHttpRoute("GetUserType", "user/getusertype", new { controller = "User", action = "GetUserType" });       

            //ADMINUSERS
            routes.MapHttpRoute("GetAdminUser", "adminuser/get", new { controller = "AdminUser", action = "Get" });
            routes.MapHttpRoute("GetAdminUserByLogin", "adminuser/getbylogin", new { controller = "AdminUser", action = "GetByLogin" });
            routes.MapHttpRoute("MergeAdminUser", "adminuser/merge", new { controller = "AdminUser", action = "Merge" });

            //SUBJECTS
            routes.MapHttpRoute("GetSubject", "subject/get", new { controller = "Subject", action = "Get" });
            routes.MapHttpRoute("MergeSubject", "subject/merge", new { controller = "Subject", action = "Merge" });

            //COURSES
            routes.MapHttpRoute("GetCourse", "course/get", new { controller = "Course", action = "Get" });
            routes.MapHttpRoute("MergeCourse", "course/merge", new { controller = "Course", action = "Merge" });
            routes.MapHttpRoute("GetSubjectCourses", "course/getbysubject", new { controller = "Course", action = "GetBySubject" });

            //COLLECTIONS
            routes.MapHttpRoute("GetCollection", "collection/get", new { controller = "Collection", action = "Get" });
            routes.MapHttpRoute("MergeCollection", "collection/merge", new { controller = "Collection", action = "Merge" });

            //QUESTIONS
            routes.MapHttpRoute("GetQuestions", "question/get", new { controller = "Question", action = "Get" });
            routes.MapHttpRoute("MergeQuestion", "question/merge", new { controller = "Question", action = "Merge" });
            routes.MapHttpRoute("SearchQuestion", "question/search", new { controller = "Question", action = "Search" });

            //RESPONSES
            routes.MapHttpRoute("GetResponse", "response/get", new { controller = "Response", action = "Get" });
            routes.MapHttpRoute("MergeResponse", "response/merge", new { controller = "Response", action = "Merge" });
            routes.MapHttpRoute("SearchResponse", "response/search", new { controller = "Response", action = "Search" });

            //GAMES
            routes.MapHttpRoute("GetGame", "game/get", new { controller = "Game", action = "Get" });
            routes.MapHttpRoute("MergeGame", "game/merge", new { controller = "Game", action = "Merge" });

            //GAMECOMPLETIONS
            routes.MapHttpRoute("GetGameCompletion", "gamecompletion/get", new { controller = "GameCompletion", action = "Get" });
            routes.MapHttpRoute("MergeGameCompletion", "gamecompletion/merge", new { controller = "GameCompletion", action = "Merge" });
            routes.MapHttpRoute("SearchGameCompletion", "gamecompletion/search", new { controller = "GameCompletion", action = "Search" });

            //COMPETITIONS
            routes.MapHttpRoute("GetCompetition", "competition/get", new { controller = "Competition", action = "Get" });
            routes.MapHttpRoute("MergeCompetition", "competition/merge", new { controller = "Competition", action = "Merge" });
            routes.MapHttpRoute("GetActiveCompetition", "competition/getactive", new { controller = "Competition", action = "GetActive" });

            //RAFFELENTRIES - 9
            routes.MapHttpRoute("GetRaffelEntry", "raffelentry/get", new { controller = "RaffelEntry", action = "Get" });
            routes.MapHttpRoute("MergeRaffelEntry", "raffelentry/merge", new { controller = "RaffelEntry", action = "Merge" });
            routes.MapHttpRoute("GetUserCompetitionRaffelEntry", "raffelentry/getbyusercompetition", new { controller = "RaffelEntry", action = "GetByUserCompetition" });
            routes.MapHttpRoute("GetWinningRaffelEntry", "raffelentry/getwinning", new { controller = "RaffelEntry", action = "GetWinning" });

            //SCHOOLSCORES - 10
            routes.MapHttpRoute("GetSchoolScore", "schoolscore/get", new { controller = "SchoolScore", action = "Get" });
            routes.MapHttpRoute("MergeSchoolScore", "schoolscore/merge", new { controller = "SchoolScore", action = "Merge" });
            routes.MapHttpRoute("GetSchoolCompetitionScores", "schoolscore/getbyschoolcompetition", new { controller = "SchoolScore", action = "GetBySchoolCompetition" });
            routes.MapHttpRoute("GetTopTenCompetitionSchools", "schoolscore/getwinning", new { controller = "SchoolScore", action = "GetWinning" });
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new APIKeyMessageHandler());
        }
    }
}
