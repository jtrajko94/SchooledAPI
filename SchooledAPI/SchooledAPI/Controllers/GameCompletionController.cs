using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class GameCompletionController : ApiController
    {
        /*
         * .../gamecompletion/get/?id= [HttpGet]
         * Description: Get a game completion with an ID, or all with null
         * Parameters: id (id of a game completion), pass null for all game completions
         * Result: APIResponseData with the full game completion object
         */
        [HttpGet]
        public APIResponseData Get(string id)
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

        /*
         * .../gamecompletion/merge/?gamecompletionjson= [HttpPost]
         * Description: Pass a game completion object to either create or update a game completion based on the Row Key
         * Parameters: gamecompletionjson (a game completion object)
         * Result: APIResponse of the Guid of the inserted/edited game completion
         */
        [HttpPost]
        public APIResponseData Merge(string gamecompletionjson)
        {
            try
            {
                GameCompletionData gameCompletion = JsonConvert.DeserializeObject<GameCompletionData>(gamecompletionjson);
                using (var sql = new SqlData.Record<string>())
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
                            UserRowKey = gameCompletion.UserRowKey
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeGameCompletion, parameters);
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
         * .../response/search/?competitionid=&courseid=&userid=&gameid= [HttpGet]
         * Description: Get list of game completions
         * Parameters: competitionid, courseid, userid, gameid
         * Result: APIResponseData of the game completion with the given criteria
         */
        [HttpGet]
        public APIResponseData Search(string competitionid, string courseid, string userid, string gameid)
        {
            try
            {
                using (var sql = new SqlData.Records<ResponseData>())
                {
                    var parameters = new
                    {
                        CompetitionRowKey = competitionid,
                        UserRowKey = userid,
                        CourseRowKey = courseid,
                        GameRowKey = gameid
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.SearchGameCompletion, parameters);
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