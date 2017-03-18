using System.Collections.Generic;
using atst.Core.Game.Entities;

namespace atst.Core.Game.Experience
{
    public interface IXpAggregator
    {
        int CalculateXp(IList<Xp> xpEntries);
    }
}