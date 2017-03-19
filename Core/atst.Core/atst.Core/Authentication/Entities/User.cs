using System.Collections.Generic;
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
    }
}
