using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class SubjectController : Controller
    {
        [HttpGet]
        public static APIResponseData GetSubject(int? id = null)
        {
            try
            {
                using (var sql = new SqlData.Records<SubjectData>())
                {
                    var parameters = new
                    {
                        SubjectRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSubject, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData DeleteSubject(int id)
        {
            try
            {
                using (var sql = new SqlData.Command())
                {
                    var parameters = new
                    {
                        SubjectRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteSubject, parameters);
                    return new APIResponseData { status = "Success", description = "Subject with ID: " + id + " has been deleted" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeSubject(SubjectData subject)
        {
            try
            {
                using (var sql = new SqlData.Record<SubjectData>())
                {
                    APIValidatorResponse response = SubjectService.IsValid(subject);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            SubjectRowKey = subject.SubjectRowKey,
                            Name = subject.Name,
                            Image = subject.Image,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSubject, parameters);
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