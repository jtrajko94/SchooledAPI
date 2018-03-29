using SchooledAPI.Data;
using SchooledAPI.Services;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class APIKeyController : ApiController
    {
        /*
         * .../apikey/get/ [HttpPost]
         * Description: Get the details about an API Key
         * Parameters: key (The API key you would like further information on)
         * Result: APIResponseData with key information
         */
        [HttpPost]
        public APIResponseData Get(string key)
        {
            return APIKeyService.GetAPIKey(key);
        }

        /*
         * .../apikey/create/ [HttpPost]
         * Description: Generate an API Key
         * Parameters: None
         * Result: APIResponseData with the Row Key of the API Key created
         */
        [HttpPost]
        public APIResponseData Create()
        {
            return APIKeyService.CreateAPIKey();
        }
    }
}