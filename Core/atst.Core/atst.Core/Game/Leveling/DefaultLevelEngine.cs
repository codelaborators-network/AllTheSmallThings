using System;
using System.Linq;
using atst.Core.Authentication.Entities;
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


        public int CalculateLevel(User user)
        {
            var level = 1;

            var xp = user.XpHistory.Any() ? _xpAggregator.CalculateXp(user.XpHistory) : 0;

            if (xp>0)
            {
                level = (int) (LevelerValue * Math.Sqrt(xp));
            }

            return level;
        }
    }
}
