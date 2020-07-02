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
    internal static class AuthRequest
    {
        internal static async Task<Token> Authorization(string authCode)
        {
            var tokenRequest = new MainGetToken(authCode);
            using (HttpClient client = new HttpClient())
            {
                string uri;
                if (!URI.ShikiUrls.TryGetValue(Link.Auth, out uri))
                {
                    throw new NoUriDictionaryException();
                }
                var request = await client.PostAsync(uri, tokenRequest.GetHttpContent()).ConfigureAwait(false);
                if (request.StatusCode == HttpStatusCode.OK)
                {
                    var str = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<Token>(str);
                }
                else
                {
                    throw new AuthCodeFailedException();
                }

            }
        }

        internal static async Task<Token> Authorization(Token token)
        {
            var refreshTokenRequest = new RefreshGetToken(token.RefreshToken);
            using (HttpClient client = new HttpClient())
            {
                string uri;
                if (!URI.ShikiUrls.TryGetValue(Link.Auth, out uri))
                {
                    throw new NoUriDictionaryException();
                }
                var request = await client.PostAsync(uri, refreshTokenRequest.GetHttpContent()).ConfigureAwait(false);
                if (request.StatusCode == HttpStatusCode.OK)
                {
                    var str = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<Token>(str);
                }
                else
                {
                    throw new AuthCodeFailedException();
                }

            }
        }
    }
}
