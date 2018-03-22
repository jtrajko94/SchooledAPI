namespace SchooledAPI.Utilities
{
    public class SqlProcedureData
    {
        public enum Procedures
        {
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
            DeleteGame
        }
    }
}