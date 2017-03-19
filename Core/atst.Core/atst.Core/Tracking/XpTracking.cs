using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Entities;
using atst.Core.Game.Experience;
using atst.Core.Game.Gear;
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
        private readonly IArmoury _armoury;

        public XpTracking(IFirebaseHelper firebaseHelper, ILevelEngine levelEngine, IXpAggregator xpAggregator, IArmoury armoury)
        {
            _firebaseHelper = firebaseHelper;
            _levelEngine = levelEngine;
            _xpAggregator = xpAggregator;
            _armoury = armoury;
        }

        public bool ApplyTracking(string xpModelUserName, int xpModelXp, IntegrationsProviderTypes integrationProvider, ActionType actionType)
        {
            var success = true;

            var user = GetUser(xpModelUserName);

            #region xp logic
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
            #endregion xp logic

            #region level logic

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
            #endregion level logic

            #region Gear

            var totalGearToAdd = xpModelXp / 50;

            for (var i = 0; i < totalGearToAdd; i++)
            {
                try
                {
                    var gearItem = _armoury.CreateRandomWeapon();

                    var eventItem = new GeneralItem(gearItem.Id, ActionType.Add);
                    _firebaseHelper.CreateGearRecordAsync(xpModelUserName.Replace('.', ','), eventItem);
                }
                catch (Exception e)
                {
                    return false;
                }
            }


            #endregion Gear

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
