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
using System.Collections.Concurrent;

namespace ShikiHuiki.Requests
{
    internal static class UserAnimeRequest
    {
        internal static async Task GetUserAnime(User currentUser, Token authToken, int limitByReq, List<UserAnimeRate> inputList)
        {
            using (HttpClient client = ClientWithHeaders(authToken.AccessToken))
            {
                string url;
                if (!URI.ShikiUrls.TryGetValue(Link.AnimeList, out url))
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

        internal static async Task GetSpecialAnime(User user, Token token,ConcurrentBag<SpecialUserAnimeRate> outContainer,AnimeStatus status = AnimeStatus.None)
        {
            using (HttpClient client = ClientWithHeaders(token.AccessToken))
            {
                string url;
                if (!URI.ShikiUrls.TryGetValue(Link.AnimeListV2, out url))
                {
                    throw new NoUriDictionaryException();
                }
                url = (status == AnimeStatus.None) ? string.Format(url, user.Id) : string.Concat(string.Format(url, user.Id),"&status=",AnimeParams.AnimeStatusString[status]);
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var array = JsonConvert.DeserializeObject<List<SpecialUserAnimeRate>>(str);
                    outContainer.AddRange(array);
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
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
            {
                @this.Add(element);
            }
        }
    }
}
