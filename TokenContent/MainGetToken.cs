using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikiHuiki.Interfaces;

namespace ShikiHuiki.TokenContent
{
    internal class MainGetToken : IRequest
    {
        internal MainGetToken(string authCode)
        {
            this.Code = authCode;
        }
        public HttpContent GetHttpContent()
        {
            var json = JsonConvert.SerializeObject(this);
            var httpcont = new StringContent(json, Encoding.UTF8, "application/json");
            httpcont.Headers.TryAddWithoutValidation("User-Agent", "MamaYaProgrammist");
            return httpcont;
        }
        [JsonProperty("grant_type")] private string G_type { get; } = "authorization_code";
        [JsonProperty("client_id")] private string C_id { get; } = "qiqJPDxgOqRGHTKqyluX-lJSQYTH9q0LD1Kel_vROXg";
        [JsonProperty("client_secret")] private string C_s { get; } = "bVVCPQOdZZrHKTqljFSVvk-wAcTDjyX2Wa3vMcMHL2w";
        [JsonProperty("code")] private string Code { get; set; }
        [JsonProperty("redirect_uri")] private string R_uri { get; } = "urn:ietf:wg:oauth:2.0:oob";
    }
}
