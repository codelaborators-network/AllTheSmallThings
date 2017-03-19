using System;
using System.Collections.Generic;
using System.Linq;
using atst.Core.Authentication.Entities;

namespace atst.Core.Stats.Entities
{
    public class ExtendedUser : User
    {
        public Dictionary<DateTime, int> TodaysCheckins
        {
            get
            {
                return XpHistory.Where(x => x.DateTime >= DateTime.UtcNow.Date).ToDictionary(x => x.DateTime, x => x.Value);
            }
        }

        public int XpForToday
        {
            get
            {
                return TodaysCheckins.Sum(x => x.Value);
            }
        }

        public Dictionary<DateTime, int> YesterdaysCheckins
        {
            get
            {
                return XpHistory.Where(x => x.DateTime >= DateTime.UtcNow.Date.AddDays(-1) && x.DateTime < DateTime.UtcNow.Date).ToDictionary(x => x.DateTime, x => x.Value);
            }
        }

        public int XpForYesterday
        {
            get
            {
                return YesterdaysCheckins.Sum(x => x.Value);
            }
        }

        public double AverageCheckinsPerHourForYesterday
        {
            get
            {
                var firstCheckin = YesterdaysCheckins.OrderByDescending(x => x.Key).Select(x => x.Key).FirstOrDefault();
                var lastCheckin = YesterdaysCheckins.OrderByDescending(x => x.Key).Select(x => x.Key).LastOrDefault();

                if (firstCheckin != null && lastCheckin != null && firstCheckin != lastCheckin)
                {
                    return YesterdaysCheckins.Count / (firstCheckin - lastCheckin).TotalHours;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
