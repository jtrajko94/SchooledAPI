using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        public APIResponseData CreateUser()
        {
            return null;
            //try
            //{
            //    using (var sql = new SqlData.Record<Guid>())
            //    {
            //        var parameters = new
            //        {
            //            UserRowKey = Guid.NewGuid(),
            //            UserTypeRowKey = user.UserTypeRowKey,
            //            SchoolRowKey = user.SchoolRowKey,
            //            Email = user.Email,
            //            Password = user.Password,
            //            FirstName = user.FirstName,
            //            LastName = user.LastName,
            //            IsFacebook = user.IsFacebook,
            //            GameDifficulty = user.GameDifficulty,
            //            Timestamp = DateTime.Now,
            //            CreatedOn = user.CreatedOn
            //        };
            //        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeUser, parameters);
            //        return new APIResponseData { status = "Success", description = sql.Run().ToString() };
            //    }
            //}
            //catch (Exception err)
            //{
            //    return new APIResponseData { status = "Failed", description = err.Message };
            //}
        }
    }
}