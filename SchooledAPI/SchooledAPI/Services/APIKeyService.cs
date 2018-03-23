using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System;

namespace SchooledAPI.Services
{
    public class APIKeyService
    {
        public static APIResponseData CreateAPIKey()
        {
            try
            {
                using (var sql = new SqlData.Records<APIKeyData>())
                {
                    var parameters = new
                    {
                        APIRowKey = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        ExpiredDate = DateTime.Now.AddMinutes(5)
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.CreateAPIKey, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        public static APIResponseData GetAPIKey(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    using (var sql = new SqlData.Record<APIKeyData>())
                    {
                        var parameters = new
                        {
                            APIRowKey = Guid.NewGuid().ToString(),
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetAPIKey, parameters);
                        return new APIResponseData
                        {
                            status = "Success",
                            description = JsonConvert.SerializeObject(sql.Run())
                        };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "API Key is required" };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }
    }
}