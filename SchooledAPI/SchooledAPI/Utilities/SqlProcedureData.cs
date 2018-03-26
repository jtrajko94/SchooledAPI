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
            GetBySubject,

            //QUESTIONS
            GetQuestion,
            MergeQuestion,
            SearchQuestion,

            //RESPONSE
            GetResponse,
            MergeResponse,
            GetQuestionResponses,

            //SCHOOLS
            GetSchool,
            MergeSchool,
            DeleteSchool,
            GetSchoolType,
            MergeSchoolType,
            SearchSchool,

            //COLLECTION
            GetCollection,
            MergeCollection,

            //GAME
            GetGame,
            MergeGame,
            DeleteGame,

            //GAMECOMPLETION
            GetGameCompletion,
            MergeGameCompletion,

            //COMPETITIONS
            GetCompetition,
            MergeCompetition,
            DeactivateCompetition,
            GetActiveCompetition,

            //RAFFELENTRY
            GetRaffelEntry,
            MergeRaffelEntry,
            GetUserCompetitionRaffelEntry,
            GetWinningRaffelEntry,

            //SCHOOLSCORES
            GetSchoolScore,
            MergeSchoolScore,
            GetSchoolCompetitionScores,
            GetTopTenCompetitionSchools
        }
    }
}