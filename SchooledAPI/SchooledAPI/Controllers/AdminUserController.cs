using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class AdminUserController : ApiController
    {
        /*
         * .../adminuser/get/?id= [HttpPost]
         * Description: Get an Admin User with an ID
         * Parameters: id (id of an Admin User), pass null for all admin users
         * Result: APIResponseData with the full Admin User object
         */
        [HttpPost]
        public APIResponseData Get(string id)
        {
            try
            {
                using (var sql = new SqlData.Records<AdminUserData>())
                {
                    var parameters = new
                    {
                        AdminUserRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetAdminUser, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../adminuser/getbylogin/?email=&password= [HttpPost]
         * Description: Get an Admin User with login information
         * Parameters: email (The email of the admin user) and password (the password of the admin user)
         * Result: APIResponseData with the full Admin User Object
         */
        [HttpPost]
        public APIResponseData GetByLogin(string email, string password)
        {
            try
            {
                if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    using (var sql = new SqlData.Record<AdminUserData>())
                    {
                        var parameters = new
                        {
                            Email = email,
                            Password = BCrypt.Net.BCrypt.HashPassword(password, Settings.AdminBcryptSalt),
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetAdminUserByLogin, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
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
         * .../adminuser/merge/?adminuserjson= [HttpPost]
         * Description: Pass an admin user object to either create or update an admin user based on the Row Key
         * Parameters: admin user json (an admin user object)
         * Result: APIResponse of the Guid of the inserted/edited admin user
         */
        [HttpPost]
        public APIResponseData Merge(string adminuserjson)
        {
            try
            {
                AdminUserData user = JsonConvert.DeserializeObject<AdminUserData>(adminuserjson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse response = AdminUserService.IsValid(user);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            AdminUserRowKey = user.AdminUserRowKey,
                            Email = user.Email,
                            Password = BCrypt.Net.BCrypt.HashPassword(user.Password, Settings.AdminBcryptSalt),
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeAdminUser, parameters);
                        return new APIResponseData { status = "Success", description = sql.Run() };
                    }
                    else
                    {
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