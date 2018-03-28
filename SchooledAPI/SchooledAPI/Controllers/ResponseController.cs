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
        /*
         * .../response/get/?id= [HttpGet]
         * Description: Get a specific resoponse by ID
         * Parameters: id (a response object)
         * Result: APIResponseData of the response object 
         */
        [HttpGet]
        public APIResponseData Get(string id)
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

        /*
         * .../response/merge/?responsejson= [HttpPost]
         * Description: Pass a response object to either create or update a response based on the Row Key
         * Parameters: response json (a response object)
         * Result: APIResponse of the Guid of the inserted/edited response
         */
        [HttpPost]
        public APIResponseData Merge(string responsejson)
        {
            try
            {
                ResponseData response = JsonConvert.DeserializeObject<ResponseData>(responsejson);
                using (var sql = new SqlData.Record<string>())
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
                            UserRowKey = response.UserRowKey
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeResponse, parameters);
                        return new APIResponseData { status = "Success", description = sql.Run() };
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

        /*
         * .../response/search/?questionid=&userid= [HttpGet]
         * Description: Get list of responses
         * Parameters: questionid, userid
         * Result: APIResponseData of the response with the given criteria
         */
        [HttpGet]
        public APIResponseData Search(string questionid, string userid)
        {
            try
            {
                if(questionid != null && userid != null)
                {
                    using (var sql = new SqlData.Records<ResponseData>())
                    {
                        var parameters = new
                        {
                            QuestionRowKey = questionid,
                            UserRowKey = userid
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.SearchQuestion, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }else
                {
                    return new APIResponseData { status = "Failed", description = "Question Id and User Id is required." };
                }
                
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

    }
}