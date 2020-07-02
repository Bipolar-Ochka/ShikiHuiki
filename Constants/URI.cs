using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Constants
{
    static internal class URI
    {
        public static Dictionary<string, string> ShikiUrls { get; } = new Dictionary<string, string>()
        {
            {"WhoAmI","https://shikimori.one/api/users/whoami"},
            {"UserAnime","https://shikimori.one/api/users/{0}/anime_rates"},
            {"History","https://shikimori.one/api/users/{0}/history" },
            {"UserRates","https://shikimori.one/api/v2/user_rates/{0}" },
            {"Increment","https://shikimori.one/api/v2/user_rates/{0}/increment" },
            {"Auth","https://shikimori.one/oauth/token" },
            {"UserRates_V2","https://shikimori.one/api/v2/user_rates?user_id={0}" },
        };
        
    }
}
