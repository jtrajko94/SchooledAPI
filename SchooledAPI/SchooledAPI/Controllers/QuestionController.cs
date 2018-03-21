using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class QuestionController : Controller
    {
        [HttpGet]
        public static APIResponseData GetQuestion(int? id = null)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Records<CourseData>())
                    {
                        var parameters = new
                        {
                            QuestionId = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetQuestion, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }else
                {
                    return new APIResponseData { status = "Failed", description = "A Question ID is required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData DeleteQuestion(int id)
        {
            try
            {
                using (var sql = new SqlData.Command())
                {
                    var parameters = new
                    {
                        QuestionId = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteQuestion, parameters);
                    return new APIResponseData { status = "Success", description = "Question with ID: " + id + " has been deleted" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeQuestion(QuestionData question)
        {
            try
            {
                using (var sql = new SqlData.Record<QuestionData>())
                {
                    APIValidatorResponse response = QuestionService.IsValid(question);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            QuestionId = question.QuestionRowKey,
                            Question = question.Question,
                            CollectionId = question.CollectionRowKey,
                            CourseId = question.CourseRowKey,
                            Difficulty = question.Difficulty,
                            CorrectAnswer = question.CorrectAnswer,
                            TotalAnswers = question.TotalAnswers,
                            AnswerOne = question.AnswerOne,
                            AnswerTwo = question.AnswerTwo,
                            AnswerThree = question.AnswerThree,
                            AnswerFour = question.AnswerFour,
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeQuestion, parameters);
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
        public static APIResponseData GetCourseQuestions(int? courseId = null)
        {
            try
            {
                if(courseId != null)
                {
                    using (var sql = new SqlData.Records<CourseData>())
                    {
                        var parameters = new
                        {
                            CourseId = courseId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCourseQuestions, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Course Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetCollectionQuestions(int? collectionId = null)
        {
            try
            {
                if (collectionId != null)
                {
                    using (var sql = new SqlData.Records<CourseData>())
                    {
                        var parameters = new
                        {
                            CollectionId = collectionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCollectionQuestions, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Collection Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}