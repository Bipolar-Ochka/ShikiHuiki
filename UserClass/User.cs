using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikiHuiki.UserClass
{
    public class User
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("nickname")] public string Name { get; set; }
        [JsonProperty("avatar")] public string AvatarLink { get; set; }
    }
}
