using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class GameController : ApiController
    {
        /*
         * .../game/get/?id= [HttpGet]
         * Description: Get a game with an ID, or all with null
         * Parameters: id (id of a game), pass null for all games
         * Result: APIResponseData with the full game object
         */
        [HttpGet]
        public APIResponseData Get(string id)
        {
            try
            {
                using (var sql = new SqlData.Records<GameData>())
                {
                    var parameters = new
                    {
                        GameRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetGame, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../game/merge/?gamejson= [HttpPost]
         * Description: Pass a game object to either create or update a game based on the Row Key
         * Parameters: gamejson (a game object)
         * Result: APIResponse of the Guid of the inserted/edited game
         */
        [HttpPost]
        public APIResponseData Merge(string gamejson)
        {
            try
            {
                GameData game = JsonConvert.DeserializeObject<GameData>(gamejson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse validatorResponse = GameService.IsValid(game);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            GameRowKey = game.GameRowKey,
                            Image = game.Image,
                            Name = game.Name
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeGame, parameters);
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
    }
}