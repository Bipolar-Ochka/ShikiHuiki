using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikiHuiki.Anime
{
    public class BaseAnime
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string NameRus { get; set; }
        [JsonProperty("score")] public string Score { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("episodes")] public long EpisodesTotal { get; set; }
        [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }
    }
}
