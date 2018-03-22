using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class GameCompletionController : Controller
    {
        [HttpGet]
        public static APIResponseData GetGameCompletion(int? id = null)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Record<GameCompletionData>())
                    {
                        var parameters = new
                        {
                            GameCompletionRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetGameCompletion, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Game Completion ID is required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeGameCompletion(GameCompletionData gameCompletion)
        {
            try
            {
                using (var sql = new SqlData.Record<GameCompletionData>())
                {
                    APIValidatorResponse validatorResponse = GameCompletionService.IsValid(gameCompletion);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            GameCompletionRowKey = gameCompletion.GameCompletionRowKey,
                            CompetitionRowKey = gameCompletion.CompetitionRowKey,
                            CourseRowKey = gameCompletion.CourseRowKey,
                            Difficulty = gameCompletion.Difficulty,
                            GameRowKey = gameCompletion.GameRowKey,
                            Points = gameCompletion.Points,
                            RaffelTickets = gameCompletion.RaffelTickets,
                            UserRowKey = gameCompletion.UserRowKey,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeGameCompletion, parameters);
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
    }
}