using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class ResponseController : ApiController
    {
        [HttpGet]
        public static APIResponseData GetResponse(int? id = null)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Record<ResponseData>())
                    {
                        var parameters = new
                        {
                            ResponseRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetResponse, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }else
                {
                    return new APIResponseData { status = "Failed", description = "A Response ID is required." };
                }
                
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeResponse(ResponseData response)
        {
            try
            {
                using (var sql = new SqlData.Record<QuestionData>())
                {
                    APIValidatorResponse validatorResponse = ResponseService.IsValid(response);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            ResponseRowKey = response.ResponseRowKey,
                            GameCompletionRowKey = response.GameCompletionRowKey,
                            QuestionRowKey = response.QuestionRowKey,
                            ChosenAnswer = response.ChosenAnswer,
                            IsCorrect = response.IsCorrect,
                            UserRowKey = response.UserRowKey,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeResponse, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                    else
                    {
                        return new APIResponseData { status = "Failed : Validation", description = JsonConvert.SerializeObject(validatorResponse.Errors) };
                    }

                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetQuestionResponses(int? questionId = null)
        {
            try
            {
                if (questionId != null)
                {
                    using (var sql = new SqlData.Records<CourseData>())
                    {
                        var parameters = new
                        {
                            QuestionRowKey = questionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetQuestionResponses, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Question Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

    }
}