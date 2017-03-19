using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Entities;
using atst.Core.Game.Experience;
using atst.Core.Game.Leveling;
using atst.Core.Helpers;
using atst.Core.Integration;

namespace atst.Core.Tracking
{
    public class XpTracking : IXpTracking
    {
        private readonly IFirebaseHelper _firebaseHelper;
        private readonly ILevelEngine _levelEngine;
        private readonly IXpAggregator _xpAggregator;

        public XpTracking(IFirebaseHelper firebaseHelper, ILevelEngine levelEngine, IXpAggregator xpAggregator)
        {
            _firebaseHelper = firebaseHelper;
            _levelEngine = levelEngine;
            _xpAggregator = xpAggregator;
        }

        public bool ApplyTracking(string xpModelUserName, int xpModelXp, IntegrationsProviderTypes integrationProvider, ActionType actionType)
        {
            var success = true;

            var user = GetUser(xpModelUserName);
            user.Xp += xpModelXp;

            try
            {
                var eventItem = new EventItem(xpModelXp, integrationProvider, actionType);
                _firebaseHelper.CreateXPRecordAsync(xpModelUserName.Replace('.', ','), eventItem);
            }
            catch (Exception e)
            {
                return false;
            }

            var orginallevel = user.Level;

            user = GetUser(xpModelUserName);
            _levelEngine.CalculateLevel(user);

            if (user.Level > orginallevel)
            {
                try
                {
                    var eventItem = new GeneralItem(user.Level, ActionType.Add);
                    _firebaseHelper.CreateLevelRecordAsync(xpModelUserName.Replace('.', ','), eventItem);
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        private User GetUser(string userName)
        {
            userName = userName.Replace('.', ',');

            var user = _firebaseHelper.GetUserAsync(userName).Result ?? new User { UserName = userName };

            var level = user.LevelHistory.OrderByDescending(x => x.DateTime).FirstOrDefault();

            user.Level = level?.Value ?? 0;
            user.Xp = _xpAggregator.CalculateXp(user.XpHistory);
            _levelEngine.CalculateLevel(user);

            return user;
        }
    }
}
