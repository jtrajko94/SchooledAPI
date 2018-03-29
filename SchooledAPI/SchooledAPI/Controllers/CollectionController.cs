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
        /*
         * .../collection/get/?id= [HttpPost]
         * Description: Get a specific collection by ID, all if null
         * Parameters: id (a collection object), all if null
         * Result: APIResponseData of the collection object 
         */
        [HttpPost]
        public APIResponseData Get(string id)
        {
            try
            {
                using (var sql = new SqlData.Records<CollectionData>())
                {
                    var parameters = new
                    {
                        CollectionRowKey = id
                    };
                    sql.Action = () => sql.Execute(SqlProcedureData.Procedures.GetCollection, parameters);
                    return new APIResponseData { status = "Success", description = JsonConvert.SerializeObject(sql.Run()) };
                }
            }
            catch (Exception err)
            {
                return new APIResponseData { status = "Failed", description = err.Message };
            }
        }

        /*
         * .../collection/merge/?collectionjson= [HttpPost]
         * Description: Pass a collection object to either create or update a collection based on the Row Key
         * Parameters: collectionjson (a collection object)
         * Result: APIResponse of the Guid of the inserted/edited question
         */
        [HttpPost]
        public APIResponseData Merge(string collectionjson)
        {
            try
            {
                CollectionData collection = JsonConvert.DeserializeObject<CollectionData>(collectionjson);
                using (var sql = new SqlData.Record<string>())
                {
                    APIValidatorResponse validatorResponse = CollectionService.IsValid(collection);
                    if (validatorResponse.IsValid)
                    {
                        var parameters = new
                        {
                            CollectionRowKey = collection.CollectionRowKey,
                            Image = collection.Image,
                            Name = collection.Name,
                            IsTextbook = collection.IsTextbook
                        };
                        sql.Action = () => sql.Execute(SqlProcedureData.Procedures.MergeCollection, parameters);
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
    }
}