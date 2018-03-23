using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class RaffelEntryController : Controller
    {
        [HttpGet]
        public static APIResponseData GetRaffelEntry(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Record<RaffelEntryData>())
                    {
                        var parameters = new
                        {
                            RaffelEntryRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetRaffelEntry, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "A Raffel Entry ID is required." };
                }

            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeRaffelEntry(RaffelEntryData raffelEntry)
        {
            try
            {
                using (var sql = new SqlData.Record<RaffelEntryData>())
                {
                    APIValidatorResponse validatorResponse = RaffelEntryService.IsValid(raffelEntry);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            RaffelEntryRowKey = raffelEntry.RaffelEntryRowKey,
                            CompetitionRowKey = raffelEntry.CompetitionRowKey,
                            UserRowKey = raffelEntry.UserRowKey,
                            TicketCount = raffelEntry.TicketCount,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeRaffelEntry, parameters);
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
        public static APIResponseData GetUserCompetitionRaffelEntry(string userId, string competitionId)
        {
            try
            {
                if (userId != null && competitionId != null)
                {
                    using (var sql = new SqlData.Records<RaffelEntryData>())
                    {
                        var parameters = new
                        {
                            UserRowKey = userId,
                            CompetitionRowKey = competitionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetUserCompetitionRaffelEntry, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a User Id and Competition Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpGet]
        public static APIResponseData GetWinningRaffelEntry(string competitionId)
        {
            try
            {
                if (competitionId != null)
                {
                    using (var sql = new SqlData.Records<RaffelEntryData>())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = competitionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetWinningRaffelEntry, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Competition Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}