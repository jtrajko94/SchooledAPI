using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class SchoolScoreController : ApiController
    {
        /*
         * .../schoolscore/get/?id= [HttpPost]
         * Description: Get a school score with an ID
         * Parameters: id (id of a school score)
         * Result: APIResponseData with the full school score object
         */
        [HttpPost]
        public APIResponseData Get(string id)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Record<SchoolScoreData>())
                    {
                        var parameters = new
                        {
                            SchoolScoreRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSchoolScore, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "A School Score ID is required." };
                }

            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../schoolscore/merge/?schoolscorejson= [HttpPost]
         * Description: Pass a school score object to either create or update a school score based on the Row Key
         * Parameters: schoolscorejson (a school score object)
         * Result: APIResponse of the Guid of the inserted/edited school score
         */
        [HttpPost]
        public APIResponseData Merge(string schoolscorejson)
        {
            try
            {
                SchoolScoreData schoolScore = JsonConvert.DeserializeObject<SchoolScoreData>(schoolscorejson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse validatorResponse = SchoolScoreService.IsValid(schoolScore);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            SchoolScoreRowKey = schoolScore.SchoolScoreRowKey,
                            CompetitionRowKey = schoolScore.CompetitionRowKey,
                            SchoolRowKey = schoolScore.SchoolRowKey,
                            Points = schoolScore.Points
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSchoolScore, parameters);
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
         * .../schoolscore/getbyschoolcompetition/?schoolid=&competitionid= [HttpPost]
         * Description: a schools points on a particular competition
         * Parameters: schoolid, competitionid
         * Result: APIResponseData with the competition score of a school
         */
        [HttpPost]
        public APIResponseData GetBySchoolCompetition(string schoolid, string competitionid)
        {
            try
            {
                if (schoolid != null && competitionid != null)
                {
                    using (var sql = new SqlData.Record<SchoolScoreData>())
                    {
                        var parameters = new
                        {
                            SchoolRowKey = schoolid,
                            CompetitionRowKey = competitionid
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSchoolScoreBySchoolCompetition, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a School Id and Competition Id." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../schoolscore/getwinning/?competitionid=&state=&count= [HttpPost]
         * Description: Get X places of winning schools
         * Parameters: state, competitionid, amount of records
         * Result: APIResponseData with the full winning school score objects
         */
        [HttpPost]
        public APIResponseData GetWinning(string competitionId, int? count)
        {
            try
            {
                if (competitionId != null && count != null)
                {
                    using (var sql = new SqlData.Records<SchoolScoreData>())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = competitionId,
                            RankingAmount = count
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetWinningSchoolScore, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "Please provide a Competition Id, State, and Ranking Amount." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}