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
using ShikiHuiki.TokenContent;

namespace ShikiHuiki.Requests
{
    internal static class WhoAmIRequest
    {
        internal static async Task<User> Whoami(Token token)
        {
            using (HttpClient client = ClientWithHeaders(token.AccessToken))
            {

                string url;
                if (!URI.ShikiUrls.TryGetValue(Link.WhoAmI, out url))
                {
                    throw new NoUriDictionaryException();
                }
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<User>(str);
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
