using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Constants
{
    internal enum Link
    {
        WhoAmI,
        AnimeList,
        AnimeListV2,
        Increment,
        AnimeInfo,
        Auth
    }
    static internal class URI
    {       
        public static Dictionary<Link, string> ShikiUrls { get; } = new Dictionary<Link, string>()
        {
            {Link.WhoAmI,"https://shikimori.one/api/users/whoami"},
            {Link.AnimeList,"https://shikimori.one/api/users/{0}/anime_rates"},
            {Link.Increment,"https://shikimori.one/api/v2/user_rates/{0}/increment" },
            {Link.Auth,"https://shikimori.one/oauth/token" },
            {Link.AnimeListV2,"https://shikimori.one/api/v2/user_rates?user_id={0}" },
            {Link.AnimeInfo,"https://shikimori.one/api/animes/{0}" },
        };
        
    }
}
