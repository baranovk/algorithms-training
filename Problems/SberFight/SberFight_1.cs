using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.SberFight
{
    public static class SberFight_1
    {
        private struct Event
        {
            public int Start;

            public int Finish;
        }

        public static bool Solution(List<string> time)
        {
            if (0 == time.Count) return false;

            var events = time.Select(t =>
            {
                var times = t.Split('-');
                return new Event
                {
                    Start = Convert.ToInt32(times.First().TrimStart('0')),
                    Finish = Convert.ToInt32(times.Last().TrimStart('0'))
                };
            }).OrderBy(e => e.Start).ToArray();

            for (var i = 0; i < events.Length - 1; i++)
            {
                if (events[i].Finish > events[i + 1].Start) return false;
            }

            return true;
        }
    }
}
