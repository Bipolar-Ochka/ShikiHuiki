﻿using ShikiHuiki.TokenContent;
using ShikiHuiki.UserClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ShikiHuiki.Requests.HttpContentExtensions;
using ShikiHuiki.Constants;
using ShikiHuiki.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace ShikiHuiki.Requests
{
    internal static class IncrementRequest
    {
        internal static async Task<SpecialUserAnimeRate> IncrementById(Token token, long userRateId)
        {
            using (HttpClient client = ClientWithHeaders(token.AccessToken))
            {
                string url;
                if(!URI.ShikiUrls.TryGetValue(Link.Increment, out url))
                {
                    throw new NoUriDictionaryException();
                }
                url = string.Format(url, userRateId);
                var response = await client.PostAsync(url, new StringContent("")).ConfigureAwait(false);
                if(response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<SpecialUserAnimeRate>(str);
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
