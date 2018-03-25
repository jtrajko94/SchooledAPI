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
        [HttpGet]
        public static APIResponseData GetGame(int? id = null)
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

        [HttpPost]
        public static APIResponseData MergeGame(GameData game)
        {
            try
            {
                using (var sql = new SqlData.Record<GameData>())
                {
                    APIValidatorResponse validatorResponse = GameService.IsValid(game);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            GameRowKey = game.GameRowKey,
                            Image = game.Image,
                            Name = game.Name,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeGame, parameters);
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

        [HttpPost]
        public static APIResponseData DeleteGame(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Command())
                    {
                        var parameters = new
                        {
                            GameRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeleteGame, parameters);
                        return new APIResponseData { status = "Success", description = "Game with ID: " + id + " has been deleted" };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Game Id is required" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}