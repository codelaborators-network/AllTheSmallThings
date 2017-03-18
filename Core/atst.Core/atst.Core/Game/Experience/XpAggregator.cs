using System.Collections.Generic;
using System.Linq;
using atst.Core.Game.Entities;

namespace atst.Core.Game.Experience
{
    public class XpAggregator : IXpAggregator
    {
        public int CalculateXp(IList<Xp> xpEntries)
        {
            var xp = xpEntries.Where(x => x.ActionType == ActionType.Add).Sum(x => x.Value) - xpEntries.Where(x => x.ActionType == ActionType.Remove).Sum(x => x.Value);

            if (xp < 0)
                xp = 0;

            return xp;
        }
    }
}
