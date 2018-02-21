using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class UserService
    {
        //TODO: ADD Services here
        public static List<string> GetAllTests(string one, string two)
        {
            using (var sql = new SqlData.Records<string>())
            {
                var parameters = new
                {
                    One = one,
                    Two = two
                };
                sql.Action = () => sql.Execute(SqlProcedureData.Procedures.Test, parameters);
                return sql.Run();
            }
        }
    }
}