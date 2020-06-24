using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikiHuiki.TokenContent
{
    internal class ErrorToken
    {
        [JsonProperty("error")] public string Error { get; set; }
        [JsonProperty("error_description")] public string Description { get; set; }
        [JsonProperty("state")] public string State { get; set; }
    }
}
