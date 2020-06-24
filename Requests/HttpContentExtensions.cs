using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Requests
{
    static internal class HttpContentExtensions
    {
        static internal HttpContent ShikiAddHeaders(this HttpContent content, string AccessTokenString)
        {
            content.Headers.TryAddWithoutValidation("User-Agent", "MamaYaProgrammist");
            content.Headers.TryAddWithoutValidation("Authorization", $"Bearer {AccessTokenString}");
            return content;
        }
        internal static HttpClient ClientWithHeaders(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "MamaYaProgrammist");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
            return client;
        }
    }
}
