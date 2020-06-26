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
using System.Diagnostics;

namespace ShikiHuiki.Requests
{
    internal static class UserAnimeRequest
    {
        internal static async Task GetUserAnime(User currentUser, Token authToken, int limitByReq, List<UserAnimeRate> inputList)
        {
            using (HttpClient client = ClientWithHeaders(authToken.AccessToken))
            {
                string url;
                if (!URI.ShikiUrls.TryGetValue("UserAnime", out url))
                {
                    throw new NoUriDictionaryException();
                }
                url = string.Format(url, currentUser.Id);
                url += "?page={0}&limit={1}";
                for (int i = 1; ; i++)
                {
                    var response = await client.GetAsync(string.Format(url, i, limitByReq)).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var temp = JsonConvert.DeserializeObject<List<UserAnimeRate>>(str);
                        if (temp is null)
                        {
                            break;
                        }
                        inputList.AddRange(temp);
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
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
}
