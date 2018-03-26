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
            routes.MapHttpRoute("MergeUser", "user/merge", new { controller = "User", action = "Merge" });
            routes.MapHttpRoute("GetUserType", "user/getusertype", new { controller = "User", action = "GetUserType" });       

            //ADMINUSERS
            routes.MapHttpRoute("GetAdminUser", "adminuser/get", new { controller = "AdminUser", action = "Get" });
            routes.MapHttpRoute("GetAdminUserByLogin", "adminuser/getbylogin", new { controller = "AdminUser", action = "GetByLogin" });
            routes.MapHttpRoute("MergeAdminUser", "adminuser/merge", new { controller = "AdminUser", action = "Merge" });

            //SUBJECTS - 1 Formatting/SQL/Test
            routes.MapHttpRoute("GetSubject", "subject/get", new { controller = "Subject", action = "Get" });
            routes.MapHttpRoute("MergeSubject", "subject/merge", new { controller = "Subject", action = "Merge" });

            //COURSES - 2 Formatting/SQL/Test
            routes.MapHttpRoute("GetCourse", "course/get", new { controller = "Course", action = "Get" });
            routes.MapHttpRoute("MergeCourse", "course/merge", new { controller = "Course", action = "Merge" });
            routes.MapHttpRoute("GetSubjectCourses", "course/getbysubject", new { controller = "Course", action = "GetBySubject" });

            //COLLECTIONS - 3
            routes.MapHttpRoute("GetCollection", "collection/get", new { controller = "Collection", action = "Get" });
            routes.MapHttpRoute("MergeCollection", "collection/merge", new { controller = "Collection", action = "Merge" });

            //QUESTIONS - 4 Formatting/SQL/Test (add 2,3,4 response question for testing)
            routes.MapHttpRoute("GetQuestions", "question/get", new { controller = "Question", action = "Get" });
            routes.MapHttpRoute("MergeQuestion", "question/merge", new { controller = "Question", action = "Merge" });
            routes.MapHttpRoute("SearchQuestion", "question/search", new { controller = "Question", action = "Search" });

            //RESPONSES
            routes.MapHttpRoute("GetResponse", "response/getresponse", new { controller = "Response", action = "GetResponse" });
            routes.MapHttpRoute("MergeResponse", "response/mergequestion", new { controller = "Response", action = "MergeResponse" });
            routes.MapHttpRoute("GetQuestionResponses", "response/getquestionresponses", new { controller = "Response", action = "GetQuestionResponses" });

            //GAMES
            routes.MapHttpRoute("GetGame", "game/getgame", new { controller = "Game", action = "GetGame" });
            routes.MapHttpRoute("MergeGame", "game/mergegame", new { controller = "Game", action = "MergeGame" });
            routes.MapHttpRoute("DeleteGame", "game/deletegame", new { controller = "Game", action = "DeleteGame" });

            //GAMECOMPLETIONS
            routes.MapHttpRoute("GetGameCompletion", "gamecompletion/getgamecompletion", new { controller = "GameCompletion", action = "GetGameCompletion" });
            routes.MapHttpRoute("MergeGameCompletion", "gamecompletion/mergegamecomplation", new { controller = "GameCompletion", action = "MergeGameCompletion" });

            //COMPETITIONS
            routes.MapHttpRoute("GetCompetition", "competition/getcompetition", new { controller = "Competition", action = "GetCompetition" });
            routes.MapHttpRoute("MergeCompetition", "competition/mergecompetition", new { controller = "Competition", action = "MergeCompetition" });
            routes.MapHttpRoute("DeactivateCompetition", "competition/deactivatecompetition", new { controller = "Competition", action = "DeactivateCompetition" });
            routes.MapHttpRoute("GetActiveCompetition", "competition/getactivecompetition", new { controller = "Competition", action = "GetActiveCompetition" });

            //RAFFELENTRIES
            routes.MapHttpRoute("GetRaffelEntry", "raffelentry/getraffelentry", new { controller = "RaffelEntry", action = "GetRaffelEntry" });
            routes.MapHttpRoute("MergeRaffelEntry", "raffelentry/mergeraffelentry", new { controller = "RaffelEntry", action = "MergeRaffelEntry" });
            routes.MapHttpRoute("GetUserCompetitionRaffelEntry", "raffelentry/getusercompetitionraffelentry", new { controller = "RaffelEntry", action = "GetUserCompetitionRaffelEntry" });
            routes.MapHttpRoute("GetWinningRaffelEntry", "raffelentry/getwinningraffelentry", new { controller = "RaffelEntry", action = "GetWinningRaffelEntry" });

            //SCHOOLSCORES
            routes.MapHttpRoute("GetSchoolScore", "schoolscore/getschoolscore", new { controller = "SchoolScore", action = "GetSchoolScore" });
            routes.MapHttpRoute("MergeSchoolScore", "schoolscore/mergeschoolscore", new { controller = "SchoolScore", action = "MergeSchoolScore" });
            routes.MapHttpRoute("GetSchoolCompetitionScores", "schoolscore/getschoolcompetitionscores", new { controller = "SchoolScore", action = "GetSchoolCompetitionScores" });
            routes.MapHttpRoute("GetTopTenCompetitionSchools", "schoolscore/gettoptencompetitionschools", new { controller = "SchoolScore", action = "GetTopTenCompetitionSchools" });
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new APIKeyMessageHandler());
        }
    }
}
