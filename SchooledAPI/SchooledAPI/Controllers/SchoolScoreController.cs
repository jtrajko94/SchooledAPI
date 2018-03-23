using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class SchoolScoreController : Controller
    {
        [HttpGet]
        public static APIResponseData GetSchoolScore(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Record<RaffelEntryData>())
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

        [HttpPost]
        public static APIResponseData MergeSchoolScore(SchoolScoreData schoolScore)
        {
            try
            {
                using (var sql = new SqlData.Record<SchoolScoreData>())
                {
                    APIValidatorResponse validatorResponse = SchoolScoreService.IsValid(schoolScore);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            SchoolScoreRowKey = schoolScore.SchoolScoreRowKey,
                            CompetitionRowKey = schoolScore.CompetitionRowKey,
                            SchoolRowKey = schoolScore.SchoolRowKey,
                            Points = schoolScore.Points,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeSchoolScore, parameters);
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
        public static APIResponseData GetSchoolCompetitionScores(string schoolId, string competitionId)
        {
            try
            {
                if (schoolId != null && competitionId != null)
                {
                    using (var sql = new SqlData.Records<SchoolScoreData>())
                    {
                        var parameters = new
                        {
                            SchoolRowKey = schoolId,
                            CompetitionRowKey = competitionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetSchoolCompetitionScores, parameters);
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

        [HttpGet]
        public static APIResponseData GetTopTenCompetitionSchools(string competitionId)
        {
            try
            {
                if (competitionId != null)
                {
                    using (var sql = new SqlData.Records<SchoolScoreData>())
                    {
                        var parameters = new
                        {
                            CompetitionRowKey = competitionId
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetTopTenCompetitionSchools, parameters);
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