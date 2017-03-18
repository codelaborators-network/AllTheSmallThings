using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atst.Core.Authentication;

namespace atst.Core.Tracking
{
    public class XpTracking : IXpTracking
    {
        public bool ApplyTracking(string xpModelUserName, int xpModelXp)
        {
            return true;
        }
    }
}
