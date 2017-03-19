using System;
using System.Linq;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Experience;

namespace atst.Core.Game.Leveling
{
    public class DefaultLevelEngine : ILevelEngine
    {

        private readonly IXpAggregator _xpAggregator;

        public DefaultLevelEngine(IXpAggregator xpAggregator)
        {
            _xpAggregator = xpAggregator;
        }


        public void CalculateLevel(User user)
        {
            var level = 1;

            var xp = user.XpHistory.Any() ? _xpAggregator.CalculateXp(user.XpHistory) : 0;

            if (xp>0)
            {
                level = (int) Math.Sqrt(xp);
            }

            user.Level = level;
        }
    }
}
