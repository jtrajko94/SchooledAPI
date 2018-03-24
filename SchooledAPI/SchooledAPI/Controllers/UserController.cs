using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class UserController : ApiController
    {
        /*
         * .../user/get/ [HttpGet]
         * Description: Get a specific user by ID
         * Parameters: id (an admin user object)
         * Result: APIResponseData of the user object 
         */
        [HttpGet]
        public APIResponseData Get(Guid id)
        {
            try
            {
                if(id == null)
                {
                    using (var sql = new SqlData.Record<UserData>())
                    {
                        var parameters = new
                        {
                            UserRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetUser, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "User Id is required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../user/getbylogin/ [HttpGet]
         * Description: Get a specific user by their login
         * Parameters: email (the email of the user) and password (user's password)
         * Result: APIResponseData of the user object 
         */
        [HttpGet]
        public APIResponseData GetByLogin(string email, string password)
        {
            try
            {
                if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
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
                }else
                {
                    return new APIResponseData { status = "Failed", description = "Email and Password are required." };
                }
                
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../user/merge/ [HttpPost]
         * Description: Pass an user object to either create or update a user based on the Row Key
         * Parameters: user (an user object)
         * Result: APIResponse of the Guid of the inserted/edited user
         */
        [HttpPost]
        public APIResponseData Merge(UserData user)
        {
            try
            {
                using (var sql = new SqlData.Record<Guid>())
                {
                    APIValidatorResponse response = UserService.IsValid(user);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            UserRowKey = user.UserRowKey,
                            UserTypeRowKey = user.UserTypeRowKey,
                            SchoolRowKey = user.SchoolRowKey,
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
                        return new APIResponseData { status = "Success", description = sql.Run().ToString() };
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

        /*
         * .../user/getusertype/ [HttpGet]
         * Description: Get the user type record with a given Id, all user types if null
         * Parameters: id (user type id)
         * Result: APIResponse of the User Type with that id, or all of them
         */
        [HttpGet]
        public APIResponseData GetUserType(Guid? id = null)
        {
            try
            {
                using (var sql = new SqlData.Records<UserTypeData>())
                {
                    var parameters = new
                    {
                        UserTypeRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetUserType, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}