using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class CompetitionController : ApiController
    {
        /*
         * .../competition/get/?id= [HttpGet]
         * Description: Get a competition with an ID, or all with null
         * Parameters: id (id of a competition)
         * Result: APIResponseData with the full competition object
         */
        [HttpGet]
        public APIResponseData Get(string id)
        {
            try
            {
                if(id != null)
                {
                    using (var sql = new SqlData.Record<CompetitionData>())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCompetition, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Competition ID is required." };
                }
                
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../competition/merge/?competitionjson= [HttpPost]
         * Description: Pass a competition object to either create or update a competition based on the Row Key
         * Parameters: competitionjson (a competition object)
         * Result: APIResponse of the Guid of the inserted/edited competition
         */
        [HttpPost]
        public APIResponseData Merge(string competitionjson)
        {
            try
            {
                CompetitionData competition = JsonConvert.DeserializeObject<CompetitionData>(competitionjson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse validatorResponse = CompetitionService.IsValid(competition);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = competition.CompetitionRowKey,
                            BeginDate = competition.BeginDate,
                            Country = competition.Country,
                            Description = competition.Description,
                            EndDate = competition.EndDate,
                            IsIndividual = competition.IsIndividual,
                            Name = competition.Name,
                            PrizeOneCost = competition.PrizeOneCost,
                            PrizeOneImage = competition.PrizeOneImage,
                            PrizeOneName = competition.PrizeOneName,
                            PrizeTwoCost = competition.PrizeTwoCost,
                            PrizeTwoImage = competition.PrizeTwoImage,
                            PrizeTwoName = competition.PrizeTwoName,
                            PrizeThreeCost = competition.PrizeThreeCost,
                            PrizeThreeImage = competition.PrizeThreeImage,
                            PrizeThreeName = competition.PrizeThreeName,
                            SchoolTypeRowKey = competition.SchoolTypeRowKey,
                            State = competition.State,
                            UserTypeRowKey = competition.UserTypeRowKey
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCompetition, parameters);
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
         * .../competition/getactive/?state=&isindividual= [HttpGet]
         * Description: Get Active Competitions given the type and state
         * Parameters: state and competitiontype
         * Result: APIResponseData with the full active competition objects
         */
        [HttpGet]
        public APIResponseData GetActive(string state, bool? isindividual = null)
        {
            try
            {
                if (isindividual != null)
                {
                    using (var sql = new SqlData.Records<CompetitionData>())
                    {
                        var parameters = new
                        {
                            State = state,
                            IsIndividual = isindividual
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetActiveCompetitions, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Competition type is required." };
                }

            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}