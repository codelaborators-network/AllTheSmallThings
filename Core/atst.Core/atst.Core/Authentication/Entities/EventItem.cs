using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atst.Core.Authentication.Entities
{
    public class EventItem
    {
        public int IntegrationId { get; set; }
        public string TimeStamp { get; set; }
        public int XP { get; set; }

        public EventItem(int xp, int integrationId)
        {
            IntegrationId = integrationId;
            TimeStamp = DateTime.UtcNow.ToString("O");
            XP = xp;
        }
    }
}
