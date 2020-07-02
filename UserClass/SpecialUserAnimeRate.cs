using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikiHuiki.Anime;
using ShikiHuiki.Requests;

namespace ShikiHuiki.UserClass
{
    public class SpecialUserAnimeRate : BaseUserAnimeRate
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("target_id")] public long AnimeId { get; set; }
        [JsonIgnore] public BaseAnime AnimeInfo { get; set; }
        public async Task GetAnimeInfo()
        {
            this.AnimeInfo = await AnimeInfoRequest.GetAnimeInfo(this.AnimeId).ConfigureAwait(false);
        }
    }
}
