using Newtonsoft.Json;
using ShikiHuiki.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.TokenContent
{
    internal class RefreshGetToken : IRequest
    {
        internal RefreshGetToken(string refreshToken)
        {
            this.Ref_t = refreshToken;
        }
        public HttpContent GetHttpContent()
        {
            var json = JsonConvert.SerializeObject(this);
            var httpcont = new StringContent(json, Encoding.UTF8, "application/json");
            httpcont.Headers.TryAddWithoutValidation("User-Agent", "MamaYaProgrammist");
            return httpcont;
        }
        [JsonProperty("grant_type")] private string G_type { get; } = "refresh_token";
        [JsonProperty("client_id")] private string C_id { get; } = "qiqJPDxgOqRGHTKqyluX-lJSQYTH9q0LD1Kel_vROXg";
        [JsonProperty("client_secret")] private string C_s { get; } = "bVVCPQOdZZrHKTqljFSVvk-wAcTDjyX2Wa3vMcMHL2w";
        [JsonProperty("refresh_token")] private string Ref_t { get; set; }
    }
}
