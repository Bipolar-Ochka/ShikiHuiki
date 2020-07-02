using Newtonsoft.Json;
using ShikiHuiki.Anime;
using ShikiHuiki.Constants;
using ShikiHuiki.Exceptions;
using ShikiHuiki.UserClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Requests
{
    internal static class AnimeInfoRequest
    {
        internal static async Task<BaseAnime> GetAnimeInfo(long animeId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url;
                if (!URI.ShikiUrls.TryGetValue(Link.AnimeInfo, out url))
                {
                    throw new NoUriDictionaryException();
                }
                url = string.Format(url, animeId);
                //TODO: add delay
                var response = await client.GetAsync(url).ConfigureAwait(false);
                Trace.WriteLine($"{animeId} - status{response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<BaseAnime>(str);
                }
                else
                {
                    throw new FailedRequestException();
                }
            }
        }
    }
}
