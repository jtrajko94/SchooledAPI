using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class SchoolController : ApiController
    {
        /*
         * .../school/get/?id= [HttpPost]
         * Description: Get a specific school by ID
         * Parameters: id (a school object)
         * Result: APIResponseData of the school object 
         */
        [HttpPost]
        public APIResponseData Get(string id)
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

        /*
        * .../school/merge/?schooljson= [HttpPost]
        * Description: Pass a school object to either create or update a school based on the Row Key
        * Parameters: schooljson (a school object json)
        * Result: APIResponse of the Guid of the inserted/edited school
        */
        [HttpPost]
        public APIResponseData Merge(string schooljson)
        {
            try
            {
                SchoolData school = JsonConvert.DeserializeObject<SchoolData>(schooljson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse response = SchoolService.IsValid(school);
                    if (response.IsValid)
                    {
                        Guid schoolGuid, schoolTypeGuid;

                        var parameters = new
                        {
                            SchoolRowKey = !string.IsNullOrEmpty(school.SchoolRowKey) && Guid.TryParse(school.SchoolRowKey, out schoolGuid) ? (Guid?) Guid.Parse(school.SchoolRowKey) : null,
                            SchoolTypeRowKey = !string.IsNullOrEmpty(school.SchoolTypeRowKey) && Guid.TryParse(school.SchoolTypeRowKey, out schoolTypeGuid) ? (Guid?) Guid.Parse(school.SchoolTypeRowKey) : null,
                            Name = school.Name,
                            Street = school.Street,
                            City = school.City,
                            State = school.State,
                            Zipcode = school.Zipcode,
                            Country = school.Country,
                            District = school.District,
                            StudentCount = school.StudentCount
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSchool, parameters);
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

        /*
         * .../school/search/?schooltypeid=&name=&state=&district=&country= [HttpPost]
         * Description: Get a specific school by searching
         * Parameters: schooltypeid, name(uses LIKE, can be used as a search term), state, district, country (all strings)
         * Result: APIResponseData of the schools with the given criteria
         */
        [HttpPost]
        public APIResponseData Search(string schooltypeid = null, string name = null, string state = null, string district = null, string country = null)
        {
            try
            {
                using (var sql = new SqlData.Records<SchoolData>())
                {
                        var parameters = new
                        {
                            SchoolTypeRowKey = schooltypeid,
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

        /*
         * .../school/getschooltype/?id= [HttpPost]
         * Description: Get the school type record with a given Id, all school types if empty
         * Parameters: id (school type id)
         * Result: APIResponse of the School Type with that id, or all of them
         */
        [HttpPost]
        public APIResponseData GetSchoolType(string id = null)
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
    }
}