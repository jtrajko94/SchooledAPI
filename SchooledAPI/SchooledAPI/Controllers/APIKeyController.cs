using SchooledAPI.Data;
using SchooledAPI.Services;
using System.Web.Http;

namespace SchooledAPI.Controllers
{
    public class APIKeyController : ApiController
    {
        [HttpGet]
        public APIResponseData Get(string key)
        {
            return APIKeyService.GetAPIKey(key);
        }

        [HttpGet]
        public APIResponseData Create()
        {
            return APIKeyService.CreateAPIKey();
        }
    }
}