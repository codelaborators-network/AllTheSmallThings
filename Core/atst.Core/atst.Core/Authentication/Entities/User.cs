using System;
using System.Collections.Generic;
using System.Linq;
using atst.Core.Game.Entities;

namespace atst.Core.Authentication.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Xp { get; set; }
        public IList<Xp> XpHistory { get; set; }
        public int Level { get; set; }
        public IList<GeneralEvent> LevelHistory {get;set;}
        public IList<GeneralEvent> GearHistory { get; set; }
        public IList<GeneralEvent> HealthHistory { get; set; }


        public List<Xp> TodaysCheckins
        {
            get
            {
                var value = XpHistory.Where(x => x.DateTime >= DateTime.UtcNow.Date).ToList();
                return value;
            }
        }

        public int XpForToday
        {
            get
            {
                return TodaysCheckins.Sum(x => x.Value);
            }
        }

        public List<Xp> YesterdaysCheckins
        {
            get
            {
                var value =
                    XpHistory.Where(
                            x => x.DateTime >= DateTime.UtcNow.Date.AddDays(-1) && x.DateTime < DateTime.UtcNow.Date).ToList();
                return value;
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
                var firstCheckin = YesterdaysCheckins.OrderByDescending(x => x.DateTime).Select(x => x.DateTime).FirstOrDefault();
                var lastCheckin = YesterdaysCheckins.OrderByDescending(x => x.DateTime).Select(x => x.DateTime).LastOrDefault();

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
