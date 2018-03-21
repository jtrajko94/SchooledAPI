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
    public class CourseController : Controller
    {
        [HttpGet]
        public static APIResponseData GetCourse(int? id = null)
        {
            try
            {
                using (var sql = new SqlData.Records<CourseData>())
                {
                    var parameters = new
                    {
                        CourseId = id
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

        [HttpPost]
        public static APIResponseData DeleteCourse(int id)
        {
            try
            {
                using (var sql = new SqlData.Command())
                {
                    var parameters = new
                    {
                        CourseId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteCourse, parameters);
                    return new APIResponseData { status = "Success", description = "Course with ID: " + id + " has been deleted" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeCourse(CourseData course)
        {
            try
            {
                using (var sql = new SqlData.Record<CourseData>())
                {
                    APIValidatorResponse response = CourseService.IsValid(course);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            CourseId = course.CourseId,
                            Name = course.Name,
                            Image = course.Image,
                            SubjectId = course.SubjectId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCourse, parameters);
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

        [HttpGet]
        public static APIResponseData GetSubjectCourses(int? subjectId = null)
        {
            try
            {
                using (var sql = new SqlData.Records<CourseData>())
                {
                    var parameters = new
                    {
                        SubjectId = subjectId
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSubjectCourses, parameters);
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