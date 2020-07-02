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
            int i = 0;
            List<Task> tasks = new List<Task>();
            await Task.Delay(1200).ConfigureAwait(false);
            foreach(var item in list)
            {
                tasks.Add(item.GetAnimeInfo());
                if(++i % 5 == 0)
                {
                    await Task.Delay(1200).ConfigureAwait(false);
                }
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
