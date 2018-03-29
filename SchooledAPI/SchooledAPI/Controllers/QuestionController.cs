using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class QuestionController : ApiController
    {
        /*
         * .../question/get/?id= [HttpPost]
         * Description: Get a specific question by ID
         * Parameters: id (a question object)
         * Result: APIResponseData of the question object 
         */
        [HttpPost]
        public APIResponseData Get(string id)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Record<QuestionData>())
                    {
                        var parameters = new
                        {
                            QuestionRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetQuestion, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "A Question ID is required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../question/merge/?questionjson= [HttpPost]
         * Description: Pass a question object to either create or update a question based on the Row Key
         * Parameters: questionjson (a question object)
         * Result: APIResponse of the Guid of the inserted/edited question
         */
        [HttpPost]
        public APIResponseData Merge(string questionjson)
        {
            try
            {
                QuestionData question = JsonConvert.DeserializeObject<QuestionData>(questionjson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse response = QuestionService.IsValid(question);
                    if (response.IsValid)
                    {
                        var parameters = new
                        {
                            QuestionRowKey = question.QuestionRowKey,
                            Question = question.Question,
                            CollectionRowKey = question.CollectionRowKey,
                            CourseRowKey = question.CourseRowKey,
                            Difficulty = question.Difficulty,
                            CorrectAnswer = question.CorrectAnswer,
                            TotalAnswers = question.TotalAnswers,
                            AnswerOne = question.AnswerOne,
                            AnswerTwo = question.AnswerTwo,
                            AnswerThree = question.AnswerThree,
                            AnswerFour = question.AnswerFour
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeQuestion, parameters);
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
         * .../question/search/?courseid=&collectionid=&count= [HttpPost]
         * Description: Get list of questions
         * Parameters: courseid, collectionid, count (amount of records)
         * Result: APIResponseData of the questions with the given criteria
         */
        [HttpPost]
        public APIResponseData Search(string courseid, string collectionid, int count = 10)
        {
            try
            {
                using (var sql = new SqlData.Records<QuestionData>())
                {
                    var parameters = new
                    {
                        CourseRowKey = courseid,
                        CollectionRowKey = collectionid,
                        Amount = count
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.SearchQuestion, parameters);
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