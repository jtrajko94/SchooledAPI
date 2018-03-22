using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class SchoolController : Controller
    {
        [HttpGet]
        public static APIResponseData GetSchool(int? id = null)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Record<SchoolData>())
                    {
                        var parameters = new
                        {
                            SchoolRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSchool, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "School Id required." };
                }
                
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData DeleteSchool(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Command())
                    {
                        var parameters = new
                        {
                            SchoolRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteSchool, parameters);
                        return new APIResponseData { status = "Success", description = "School with ID: " + id + " has been deleted" };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "School Id required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeSchool(SchoolData school)
        {
            try
            {
                using (var sql = new SqlData.Record<SchoolData>())
                {
                    APIValidatorResponse response = SchoolService.IsValid(school);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            SchoolRowKey = school.SchoolRowKey,
                            SchoolTypeRowKey = school.SchoolTypeRowKey,
                            Email = school.Name,
                            Street = school.Street,
                            City = school.City,
                            State = school.State,
                            Zipcode = school.Zipcode,
                            Country = school.Country,
                            District = school.District,
                            StudentCount = school.StudentCount,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSchool, parameters);
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

        [HttpPost]
        public static APIResponseData SearchSchool(string name, string state, string district, string country)
        {
            try
            {
                using (var sql = new SqlData.Records<SchoolData>())
                {
                        var parameters = new
                        {
                            Name = name,
                            State = state,
                            District = district,
                            Country = country
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.SearchSchool, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetSchoolType(int? id = null)
        {
            try
            {
                using (var sql = new SqlData.Records<SchoolTypeData>())
                {
                    var parameters = new
                    {
                        SchoolTypeRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSchoolType, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeUserType(SchoolTypeData schoolType)
        {
            try
            {
                using (var sql = new SqlData.Record<SchoolTypeData>())
                {
                    APIValidatorResponse response = SchoolTypeService.IsValid(schoolType);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            SchoolTypeRowKey = schoolType.SchoolTypeRowKey,
                            Name = schoolType.Name,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSchoolType, parameters);
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