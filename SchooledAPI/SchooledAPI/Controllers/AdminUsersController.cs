﻿using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class AdminUsersController : Controller
    {
        [HttpGet]
        public static APIResponseData GetAdminUserById(int id)
        {
            try
            {
                using (var sql = new SqlData.Record<AdminUserData>())
                {
                    var parameters = new
                    {
                        AdminUserId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetAdminUserById, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetAdminUserByLogin(string email, string password)
        {
            try
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
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData DeleteAdminUser(int id)
        {
            try
            {
                using (var sql = new SqlData.Command())
                {
                    var parameters = new
                    {
                        AdminUserId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteAdminUser, parameters);
                    return new APIResponseData { status = "Success", description = "Admin User with ID: " + id + " has been deleted" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeAdminUser(AdminUserData user)
        {
            try
            {
                using (var sql = new SqlData.Record<AdminUserData>())
                {
                    APIValidatorResponse response = AdminUserService.IsValid(user);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            UserId = user.AdminUserId,
                            Email = user.Email,
                            Password = user.Password,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Timestamp = DateTime.Now,
                            CreatedOn = user.CreatedOn
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeAdminUser, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
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