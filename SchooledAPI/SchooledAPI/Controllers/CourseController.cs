using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class CourseController : ApiController
    {
        /*
         * .../course/get/?id= [HttpPost]
         * Description: Get a specific course by ID
         * Parameters: id (a course object)
         * Result: APIResponseData of the course object 
         */
        [HttpPost]
        public APIResponseData Get(string id)
        {
            try
            {
                using (var sql = new SqlData.Records<CourseData>())
                {
                    var parameters = new
                    {
                        CourseRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCourse, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../course/merge/?coursejson= [HttpPost]
         * Description: Pass a course object to either create or update a course based on the Row Key
         * Parameters: course json (a course object)
         * Result: APIResponse of the Guid of the inserted/edited course
         */
        [HttpPost]
        public APIResponseData Merge(string coursejson = null)
        {
            try
            {
                CourseData course = JsonConvert.DeserializeObject<CourseData>(coursejson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse response = CourseService.IsValid(course);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            CourseRowKey = course.CourseRowKey,
                            Name = course.Name,
                            Image = course.Image,
                            SubjectRowKey = course.SubjectRowKey
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCourse, parameters);
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
         * .../course/getbysubject/?subjectid= [HttpPost]
         * Description: Get courses by subject
         * Parameters: subjectid
         * Result: APIResponseData of the associated courses
         */
        [HttpPost]
        public APIResponseData GetBySubject(string subjectid)
        {
            try
            {
                if (subjectid != null)
                {
                    using (var sql = new SqlData.Records<CourseData>())
                    {
                        var parameters = new
                        {
                            SubjectRowKey = subjectid
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCourseBySubject, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Subject Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}