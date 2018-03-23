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
            DeleteUser,
            GetUserType,
            MergeUserType,

            //ADMINUSERS
            GetAdminUser,
            GetAdminUserByLogin,
            MergeAdminUser,
            DeleteAdminUser,

            //SUBJECTS
            GetSubject,
            MergeSubject,
            DeleteSubject,

            //COURSES
            GetCourse,
            MergeCourse,
            DeleteCourse,
            GetSubjectCourses,

            //QUESTIONS
            GetQuestion,
            MergeQuestion,
            DeleteQuestion,
            GetCourseQuestions,
            GetCollectionQuestions,

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