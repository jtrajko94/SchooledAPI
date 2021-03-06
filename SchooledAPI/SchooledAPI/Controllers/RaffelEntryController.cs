using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class RaffelEntryController : ApiController
    {
        /*
         * .../raffelentry/get/?id= [HttpPost]
         * Description: Get a raffel entry with an ID
         * Parameters: id (id of a raffel entry)
         * Result: APIResponseData with the full raffel entry object
         */
        [HttpPost]
        public APIResponseData Get(string id)
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

        /*
         * .../raffelentry/merge/?raffelentryjson= [HttpPost]
         * Description: Pass a raffel entry object to either create or update a raffel entry based on the Row Key
         * Parameters: raffelentryjson (a raffel entry object)
         * Result: APIResponse of the Guid of the inserted/edited competition
         */
        [HttpPost]
        public APIResponseData Merge(string raffelentryjson)
        {
            try
            {
                RaffelEntryData raffelEntry = JsonConvert.DeserializeObject<RaffelEntryData>(raffelentryjson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse validatorResponse = RaffelEntryService.IsValid(raffelEntry);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            RaffelEntryRowKey = raffelEntry.RaffelEntryRowKey,
                            CompetitionRowKey = raffelEntry.CompetitionRowKey,
                            UserRowKey = raffelEntry.UserRowKey,
                            TicketCount = raffelEntry.TicketCount
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeRaffelEntry, parameters);
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
         * .../raffelentry/getactive/?userid=&competitionid= [HttpPost]
         * Description: Get the entries of a user in a competition
         * Parameters: userid and competitionid
         * Result: APIResponseData with the raffel entries
         */
        [HttpPost]
        public APIResponseData GetByUserCompetition(string userid, string competitionid)
        {
            try
            {
                if (userid != null && competitionid != null)
                {
                    using (var sql = new SqlData.Records<RaffelEntryData>())
                    {
                        var parameters = new
                        {
                            UserRowKey = userid,
                            CompetitionRowKey = competitionid
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetRaffelEntryByUserCompetition, parameters);
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

        /*
         * .../raffelentry/getwinning/?competitionid= [HttpPost]
         * Description: Get the winning raffel entry of a competition
         * Parameters: competitionid
         * Result: APIResponseData with the winning raffel entry
         */
        [HttpPost]
        public APIResponseData GetWinning(string competitionid)
        {
            try
            {
                if (competitionid != null)
                {
                    using (var sql = new SqlData.Records<RaffelEntryData>())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = competitionid
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