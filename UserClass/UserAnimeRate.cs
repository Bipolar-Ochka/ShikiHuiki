using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShikiHuiki.Anime;

namespace ShikiHuiki.UserClass
{
    public class UserAnimeRate : BaseUserAnimeRate
    {        
        [JsonProperty("user")] public User UserInfo { get; set; }
        [JsonProperty ("anime")] public BaseAnime AnimeInfo { get; set; }

    }
}
