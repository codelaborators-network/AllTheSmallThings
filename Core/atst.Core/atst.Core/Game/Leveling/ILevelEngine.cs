using System.Collections.Generic;
using atst.Core.Game.Entities;

namespace atst.Core.Game.Leveling
{
    public interface ILevelEngine
    {
        int CalculateLevel(Xp xp);
        int CalculateLevel(IList<Xp> xpEntries);
    }
}