using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public static APIResponseData GetUserById(int id)
        {
            try
            {
                using (var sql = new SqlData.Record<UserData>())
                {
                    var parameters = new
                    {
                        UserId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetUserById, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetUserByLogin(string email, string password)
        {
            try
            {
                using (var sql = new SqlData.Record<UserData>())
                {
                    var parameters = new
                    {
                        Email = email,
                        Password = password
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetUserByLogin, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData DeleteUser(int id)
        {
            try
            {
                using (var sql = new SqlData.Command())
                {
                    var parameters = new
                    {
                        UserId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteUser, parameters);
                    return new APIResponseData { status = "Success", description = "User with ID: " + id + " has been deleted" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeUser(UserData user)
        {
            try
            {
                using (var sql = new SqlData.Record<UserData>())
                {
                    APIValidatorResponse response = UserService.IsValid(user);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            UserId = user.UserId,
                            UserTypeId = user.UserTypeId,
                            SchoolId = user.SchoolId,
                            Email = user.Email,
                            Password = user.Password,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            IsFacebook = user.IsFacebook,
                            GameDifficulty = user.GameDifficulty,
                            Timestamp = DateTime.Now,
                            CreatedOn = user.CreatedOn
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeUser, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    } else {
                        return new APIResponseData { status = "Failed : Validation", description = JsonConvert.SerializeObject(response.Errors) };
                    }
                    
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}