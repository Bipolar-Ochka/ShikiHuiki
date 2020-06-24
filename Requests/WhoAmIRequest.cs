using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShikiHuiki.UserClass;
using static ShikiHuiki.Requests.HttpContentExtensions;
using ShikiHuiki.Constants;
using ShikiHuiki.Exceptions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace ShikiHuiki.Requests
{
    internal static class WhoAmIRequest
    {
        internal static async Task<User> Whoami(string accessToken)
        {
            using (HttpClient client = ClientWithHeaders(accessToken))
            {

                string url;
                if (!URI.ShikiUrls.TryGetValue("WhoAmI", out url))
                {
                    throw new NoUriDictionaryException();
                }
                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                }
                else if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new TokenExpiredException();
                }
                else
                {
                    throw new FailedRequestException();
                }
            }
        }
    }
}
