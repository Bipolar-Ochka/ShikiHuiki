using ShikiHuiki.UserClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Requests
{
    internal static class AnimeInfoForListRequest
    {
        internal static async Task InfoForList(ConcurrentBag<SpecialUserAnimeRate> list)
        {
            List<Task> tasks = new List<Task>();
            foreach(var item in list)
            {
                tasks.Add(item.GetAnimeInfo());
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
