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
         * .../adminuser/get/ [HttpGet]
         * Description: Get an Admin User with an ID
         * Parameters: id (Guid of an Admin User), pass null for all admin users
         * Result: APIResponseData with the full Admin User object
         */
        [HttpGet]
        public APIResponseData Get(Guid? id = null)
        {
            try
            {
                using (var sql = new SqlData.Record<AdminUserData>())
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
         * .../adminuser/getbylogin/ [HttpGet]
         * Description: Get an Admin User with login information
         * Parameters: email (The email of the admin user) and password (the password of the admin user)
         * Result: APIResponseData with the full Admin User Object
         */
        [HttpGet]
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
                            Password = password
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
         * .../adminuser/merge/ [HttpPost]
         * Description: Pass an admin user object to either create or update an admin user based on the Row Key
         * Parameters: user (an admin user object)
         * Result: APIResponse of the Guid of the inserted/edited admin user
         */
        [HttpPost]
        public APIResponseData Merge(AdminUserData user)
        {
            try
            {
                using (var sql = new SqlData.Record<Guid>())
                {
                    APIValidatorResponse response = AdminUserService.IsValid(user);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            UserRowKey = user.AdminUserRowKey,
                            Email = user.Email,
                            Password = user.Password,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Timestamp = DateTime.Now,
                            CreatedOn = user.CreatedOn
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeAdminUser, parameters);
                        return new APIResponseData { status = "Success", description = sql.Run().ToString() };
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