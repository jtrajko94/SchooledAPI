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
                using (var sql = new SqlData.Record<Guid>())
                {
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.CreateAPIKey);
                    return new APIResponseData { status = "Success", description = sql.Run().ToString() };
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
                if (!string.IsNullOrEmpty(key))
                {
                    using (var sql = new SqlData.Record<APIKeyData>())
                    {
                        var parameters = new
                        {
                            APIKey = Guid.Parse(key),
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