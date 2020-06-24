using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.UserClass
{
    public class BaseUserAnimeRate
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("score")] public long Score { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("episodes")] public long EpisodesWatched { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
    }
}
