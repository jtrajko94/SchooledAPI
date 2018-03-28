using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using SchooledAPI.Services;
using SchooledAPI.Data;
using Newtonsoft.Json;
using System;

namespace SchooledAPI.Utilities
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        /*
         * HEADERS Must contain "APIKey" as the key, and the actual key as the value
         */
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            if (httpRequestMessage.RequestUri.ToString().Contains("api"))
            {
                var response = await base.SendAsync(httpRequestMessage, cancellationToken);
                return response;
            }

            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);
            if (checkApiKeyExists)
            {
                APIResponseData response = APIKeyService.GetAPIKey(requestHeaders.FirstOrDefault());
                if(response.status == "Success")
                {
                    APIKeyData keyData = JsonConvert.DeserializeObject<APIKeyData>(response.description);
                    if(keyData.APIKey != null && keyData.ExpiredDate > DateTime.Now)
                    {
                        validKey = true;
                    }
                }
            }

            if (!validKey)
            {
                APIResponseData responseData = new APIResponseData{ status = "Failed", description = "Invalid API Key" };
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, JsonConvert.SerializeObject(responseData));
            }

            var finalResponse = await base.SendAsync(httpRequestMessage, cancellationToken);

            return finalResponse;
        }
    }
}