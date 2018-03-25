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
        [HttpGet]
        public static APIResponseData GetCompetition(int? id = null)
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

        [HttpPost]
        public static APIResponseData MergeCompetition(CompetitionData competition)
        {
            try
            {
                using (var sql = new SqlData.Record<CompetitionData>())
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
                            isIndividual = competition.isIndividual,
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
                            UserTypeRowKey = competition.UserTypeRowKey,
                            IsActive = competition.IsActive,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCompetition, parameters);
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
        public static APIResponseData DeactivateCompetition(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Command())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.DeactivateCompetition, parameters);
                        return new APIResponseData { status = "Success", description = "Competition with ID: " + id + " has been deactivated" };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Competition Id is required" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetActiveCompetition(string state, bool? isIndividual = null)
        {
            try
            {
                if (isIndividual != null)
                {
                    using (var sql = new SqlData.Record<CompetitionData>())
                    {
                        var parameters = new
                        {
                            State = state,
                            IsIndividual = isIndividual
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetActiveCompetition, parameters);
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