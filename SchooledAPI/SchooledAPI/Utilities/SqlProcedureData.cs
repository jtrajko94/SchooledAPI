namespace SchooledAPI.Utilities
{
    public class SqlProcedureData
    {
        public enum Procedures
        {
            //APIKEYS
            CreateAPIKey,
            GetAPIKey,

            //USERS
            GetUser,
            GetUserByLogin,
            MergeUser,
            GetUserType,

            //ADMINUSERS
            GetAdminUser,
            GetAdminUserByLogin,
            MergeAdminUser,

            //SUBJECTS
            GetSubject,
            MergeSubject,

            //COURSES
            GetCourse,
            MergeCourse,
            GetCourseBySubject,

            //QUESTIONS
            GetQuestion,
            MergeQuestion,
            SearchQuestion,

            //RESPONSE
            GetResponse,
            MergeResponse,
            SearchResponse,

            //SCHOOLS
            GetSchool,
            MergeSchool,
            GetSchoolType,
            SearchSchool,

            //COLLECTION
            GetCollection,
            MergeCollection,

            //GAME
            GetGame,
            MergeGame,

            //GAMECOMPLETION
            GetGameCompletion,
            MergeGameCompletion,
            SearchGameCompletion,

            //COMPETITIONS
            GetCompetition,
            MergeCompetition,
            GetActiveCompetitions,

            //RAFFELENTRY
            GetRaffelEntry,
            MergeRaffelEntry,
            GetRaffelEntryByUserCompetition,
            GetWinningRaffelEntry,

            //SCHOOLSCORES
            GetSchoolScore,
            MergeSchoolScore,
            GetSchoolScoresBySchoolCompetition,
            GetWinningSchoolScore
        }
    }
}