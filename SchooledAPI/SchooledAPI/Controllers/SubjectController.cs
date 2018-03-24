using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class SubjectController : ApiController
    {
        /*
         * .../subject/get/ [HttpGet]
         * Description: Get a subject with the id, or all if null
         * Parameters: id (The id of the subject)
         * Result: APIResponseData with a single or all subjects
         */
        [HttpGet]
        public APIResponseData Get(Guid? id = null)
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

        /*
         * .../subject/merge/ [HttpPost]
         * Description: Edit or Insert a subject, based on if an ID is a match or not
         * Parameters: subject (A subject object)
         * Result: APIResponseData with the Guid of the subject
         */
        [HttpPost]
        public APIResponseData Merge(SubjectData subject)
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