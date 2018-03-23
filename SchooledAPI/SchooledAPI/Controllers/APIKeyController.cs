using SchooledAPI.Data;
using SchooledAPI.Services;
using System.Web.Mvc;

namespace SchooledAPI.Controllers
{
    public class APIKeyController : Controller
    {
        public static APIResponseData CreateAPIKey()
        {
            return APIKeyService.CreateAPIKey();
        }

        [HttpPost]
        public static APIResponseData GetAPIKey(string key)
        {
            return APIKeyService.GetAPIKey(key);   
        }

    }
}