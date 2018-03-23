﻿using SchooledAPI.Utilities;
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

            //TODO on these, MAPHTTPROUTE, controller/action, Change controller to API Controller, Change return types, remove static from action methods

            //APIKeyService
            routes.MapHttpRoute("GetAPIKey", "apikey/get", new { controller = "APIKey", action = "Get" });
            routes.MapHttpRoute("CreateAPIKey", "apikey/create", new { controller = "APIKey", action = "Create" });

            //USERS
            routes.MapRoute("GetUser", "user/getuser", new { controller = "User", action = "GetUser" });
            routes.MapRoute("GetUserByLogin", "user/getuserbylogin", new { controller = "User", action = "GetUserByLogin" });
            routes.MapHttpRoute("DeleteUser", "user/deleteuser", new { controller = "User", action = "DeleteUser" });
            routes.MapRoute("MergeUser", "user/mergeuser", new { controller = "User", action = "MergeUser" });
            routes.MapRoute("GetUserType", "user/getusertype", new { controller = "User", action = "GetUserType" });
            routes.MapRoute("MergeUserType", "user/mergeusertype", new { controller = "User", action = "MergeUserType" });        

            //ADMINUSERS
            routes.MapRoute("GetAdminUser", "adminuser/getadminuser", new { controller = "AdminUser", action = "GetAdminUser" });
            routes.MapRoute("GetAdminUserByLogin", "adminuser/getadminuserbylogin", new { controller = "AdminUser", action = "GetAdminUserByLogin" });
            routes.MapRoute("DeleteAdminUser", "adminuser/deleteadminuser", new { controller = "AdminUser", action = "DeleteAdminUser" });
            routes.MapRoute("MergeAdminUser", "adminuser/mergeadminuser", new { controller = "AdminUser", action = "MergeAdminUser" });

            //SUBJECTS
            routes.MapRoute("GetSubject", "subject/getsubject", new { controller = "Subject", action = "GetSubject" });
            routes.MapRoute("DeleteSubject", "subject/deletesubject", new { controller = "Subject", action = "DeleteSubject" });
            routes.MapRoute("MergeSubject", "subject/mergesubject", new { controller = "Subject", action = "MergeSubject" });

            //COURSES
            routes.MapRoute("GetCourse", "course/getcourse", new { controller = "Course", action = "GetCourse" });
            routes.MapRoute("DeleteCourse", "course/deletecourse", new { controller = "Course", action = "DeleteCourse" });
            routes.MapRoute("MergeCourse", "course/mergecourse", new { controller = "Course", action = "MergeCourse" });
            routes.MapRoute("GetSubjectCourses", "course/getsubjectcourses", new { controller = "Course", action = "GetSubjectCourses" });

            //QUESTIONS
            routes.MapRoute("GetQuestions", "question/getquestion", new { controller = "Question", action = "GetQuestion" });
            routes.MapRoute("DeleteQuestions", "question/deletequestion", new { controller = "Question", action = "DeleteQuestion" });
            routes.MapRoute("MergeQuestion", "question/mergequestion", new { controller = "Question", action = "MergeQuestion" });
            routes.MapRoute("GetCourseQuestion", "question/getcoursequestions", new { controller = "Question", action = "GetCourseQuestions" });
            routes.MapRoute("GetCollectionQuestions", "question/getcollectionquestions", new { controller = "Question", action = "GetCollectionQuestions" });

            //RESPONSES
            routes.MapRoute("GetResponse", "response/getresponse", new { controller = "Response", action = "GetResponse" });
            routes.MapRoute("MergeResponse", "response/mergequestion", new { controller = "Response", action = "MergeResponse" });
            routes.MapRoute("GetQuestionResponses", "response/getquestionresponses", new { controller = "Response", action = "GetQuestionResponses" });

            //SCHOOLS
            routes.MapRoute("GetSchool", "school/getschool", new { controller = "School", action = "GetSchool" });
            routes.MapRoute("DeleteSchool", "school/deleteschool", new { controller = "School", action = "DeleteSchool" });
            routes.MapRoute("MergeSchool", "school/mergeschool", new { controller = "School", action = "MergeSchool" });
            routes.MapRoute("SearchSchool", "school/searchschool", new { controller = "School", action = "SearchSchool" });
            routes.MapRoute("GetSchoolType", "school/getschooltype", new { controller = "School", action = "GetSchoolType" });
            routes.MapRoute("MergeSchoolType", "school/mergeschooltype", new { controller = "School", action = "MergeSchoolType" });

            //COLLECTIONS
            routes.MapRoute("GetCollection", "collection/getcollection", new { controller = "Collection", action = "GetCollection" });
            routes.MapRoute("MergeCollection", "collection/mergecollection", new { controller = "Collection", action = "MergeCollection" });

            //GAMES
            routes.MapRoute("GetGame", "game/getgame", new { controller = "Game", action = "GetGame" });
            routes.MapRoute("MergeGame", "game/mergegame", new { controller = "Game", action = "MergeGame" });
            routes.MapRoute("DeleteGame", "game/deletegame", new { controller = "Game", action = "DeleteGame" });

            //GAMECOMPLETIONS
            routes.MapRoute("GetGameCompletion", "gamecompletion/getgamecompletion", new { controller = "GameCompletion", action = "GetGameCompletion" });
            routes.MapRoute("MergeGameCompletion", "gamecompletion/mergegamecomplation", new { controller = "GameCompletion", action = "MergeGameCompletion" });

            //COMPETITIONS
            routes.MapRoute("GetCompetition", "competition/getcompetition", new { controller = "Competition", action = "GetCompetition" });
            routes.MapRoute("MergeCompetition", "competition/mergecompetition", new { controller = "Competition", action = "MergeCompetition" });
            routes.MapRoute("DeactivateCompetition", "competition/deactivatecompetition", new { controller = "Competition", action = "DeactivateCompetition" });
            routes.MapRoute("GetActiveCompetition", "competition/getactivecompetition", new { controller = "Competition", action = "GetActiveCompetition" });

            //RAFFELENTRIES
            routes.MapRoute("GetRaffelEntry", "raffelentry/getraffelentry", new { controller = "RaffelEntry", action = "GetRaffelEntry" });
            routes.MapRoute("MergeRaffelEntry", "raffelentry/mergeraffelentry", new { controller = "RaffelEntry", action = "MergeRaffelEntry" });
            routes.MapRoute("GetUserCompetitionRaffelEntry", "raffelentry/getusercompetitionraffelentry", new { controller = "RaffelEntry", action = "GetUserCompetitionRaffelEntry" });
            routes.MapRoute("GetWinningRaffelEntry", "raffelentry/getwinningraffelentry", new { controller = "RaffelEntry", action = "GetWinningRaffelEntry" });

            //SCHOOLSCORES
            routes.MapRoute("GetSchoolScore", "schoolscore/getschoolscore", new { controller = "SchoolScore", action = "GetSchoolScore" });
            routes.MapRoute("MergeSchoolScore", "schoolscore/mergeschoolscore", new { controller = "SchoolScore", action = "MergeSchoolScore" });
            routes.MapRoute("GetSchoolCompetitionScores", "schoolscore/getschoolcompetitionscores", new { controller = "SchoolScore", action = "GetSchoolCompetitionScores" });
            routes.MapRoute("GetTopTenCompetitionSchools", "schoolscore/gettoptencompetitionschools", new { controller = "SchoolScore", action = "GetTopTenCompetitionSchools" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new APIKeyMessageHandler());
        }
    }
}
