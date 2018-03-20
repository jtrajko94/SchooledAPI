namespace SchooledAPI.Utilities
{
    public class SqlProcedureData
    {
        public enum Procedures
        {
            //USERS
            GetUserById,
            GetUserByLogin,
            MergeUser,
            DeleteUser,

            //ADMINUSERS
            GetAdminUserById,
            GetAdminUserByLogin,
            MergeAdminUser,
            DeleteAdminUser,
        }
    }
}