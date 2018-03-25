using Newtonsoft.Json;
using SchooledAPI.Data;
using SchooledAPI.Services;
using SchooledAPI.Utilities;
using System;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class CollectionController : ApiController
    {
        [HttpGet]
        public static APIResponseData GetCollection(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    using (var sql = new SqlData.Record<CollectionData>())
                    {
                        var parameters = new
                        {
                            CollectionRowKey = id
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCollection, parameters);
                        return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                    }
                }
                else
                {
                    return new APIResponseData { status = "Failed", description = "A Collection ID is required." };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        [HttpPost]
        public static APIResponseData MergeCollection(CollectionData collection)
        {
            try
            {
                using (var sql = new SqlData.Record<CollectionData>())
                {
                    APIValidatorResponse validatorResponse = CollectionService.IsValid(collection);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            CollectionRowKey = collection.CollectionRowKey,
                            Image = collection.Image,
                            Name = collection.Name,
                            IsTextbook = collection.IsTextbook,
                            Timestamp = DateTime.Now
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCollection, parameters);
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
    }
}