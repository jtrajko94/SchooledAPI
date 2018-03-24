using SchooledAPI.Data;
using SchooledAPI.Services;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class APIKeyController : ApiController
    {
        /*
         * .../apikey/get/ [HttpGet]
         * Description: Get the details about an API Key
         * Parameters: key (The API key you would like further information on)
         * Result: APIResponseData with key information
         */
        [HttpGet]
        public APIResponseData Get(string key)
        {
            return APIKeyService.GetAPIKey(key);
        }

        /*
         * .../apikey/create/ [HttpGet]
         * Description: Generate an API Key
         * Parameters: None
         * Result: APIResponseData with the Row Key of the API Key created
         */
        [HttpGet]
        public APIResponseData Create()
        {
            return APIKeyService.CreateAPIKey();
        }
    }
}