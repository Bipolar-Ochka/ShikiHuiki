using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Constants
{
    public enum AnimeStatus
    {
        Planned,
        Watching,
        Rewatching,
        Completed,
        OnHold,
        Dropped
    }
    public static class AnimeParams
    {
        public static ReadOnlyDictionary<AnimeStatus, string> AnimeStatusString = new ReadOnlyDictionary<AnimeStatus, string>(new Dictionary<AnimeStatus,string>()
        {
            {AnimeStatus.Planned, "planned" },
            {AnimeStatus.Watching , "watching" },
            {AnimeStatus.Rewatching , "rewatching" },
            {AnimeStatus.Completed , "completed" },
            {AnimeStatus.OnHold , "on_hold" },
            {AnimeStatus.Dropped , "dropped" },
        });

    }
}
