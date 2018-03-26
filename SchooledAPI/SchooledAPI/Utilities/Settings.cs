using System.Configuration;

namespace SchooledAPI.Utilities
{
    public static class Settings
    {
        //TODO: SMTP Credentials and Cloud Storage Credentials

        public static string StorageAccountConnection = ConfigurationManager.AppSettings["CloudStorage"];

        //TODO: Set schooled database connection
        public static string SchooledDatabaseConnection = ConfigurationManager.AppSettings["SchooledDb"];

        public static string MainHost = "Schooled";

        public static string EmailFromAddress = "";
        public static string EmailServer = "";
        public static string EmailUsername = "";
        public static string EmailPassword = "";
        public static int EmailPort = 0;
        public static bool EmailSsl = false;

        public static string AdminBcryptSalt = "$2a$10$Wy/talEP6QQlEj1L3K7DDu";
        public static string BcryptSalt = "$2a$10$eaXdujHaGGxH7j9JcWgf4.";
    }
}