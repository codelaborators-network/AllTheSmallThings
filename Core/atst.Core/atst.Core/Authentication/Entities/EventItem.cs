using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atst.Core.Authentication.Entities
{
    public class EventItem
    {
        public string TimeStamp { get; set; }
        public int XP { get; set; }
        
        public EventItem(int xp)
        {
            TimeStamp = DateTime.UtcNow.ToString("O");
            XP = xp;
        }
    }
}
