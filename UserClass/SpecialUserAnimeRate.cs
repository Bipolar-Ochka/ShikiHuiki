﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikiHuiki.UserClass
{
    public class SpecialUserAnimeRate : BaseUserAnimeRate
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("target_id")] public long AnimeId { get; set; }
    }
}