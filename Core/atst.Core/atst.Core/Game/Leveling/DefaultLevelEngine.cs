using System;
using System.Collections.Generic;
using atst.Core.Game.Entities;
using atst.Core.Game.Experience;

namespace atst.Core.Game.Leveling
{
    public class DefaultLevelEngine : ILevelEngine
    {
        private const int LevelerValue = 5;

        private readonly IXpAggregator _xpAggregator;

        public DefaultLevelEngine(IXpAggregator xpAggregator)
        {
            _xpAggregator = xpAggregator;
        }

        public int CalculateLevel(Xp xp)
        {
            return CalculateLevel(new[] {xp});
        }

        public int CalculateLevel(IList<Xp> xpEntries)
        {
            var level = 1;

            var xp = _xpAggregator.CalculateXp(xpEntries);

            if (xp>0)
            {
                level = (int) (LevelerValue * Math.Sqrt(xp));
            }

            return level;
        }
    }
}
