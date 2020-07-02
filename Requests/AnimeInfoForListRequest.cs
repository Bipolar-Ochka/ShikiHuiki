using ShikiHuiki.UserClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Requests
{
    internal static class AnimeInfoForListRequest
    {
        internal static async Task InfoForList(IEnumerable<SpecialUserAnimeRate> list)
        {
            var tasks = list.Select(async item => item.AnimeInfo = await AnimeInfoRequest.GetAnimeInfo(item.AnimeId).ConfigureAwait(false));
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
