using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Entities;
using atst.Core.Game.Leveling;
using atst.Core.Helpers;
using atst.Core.Integration;

namespace atst.Core.Tracking
{
    public class XpTracking : IXpTracking
    {
        private readonly IFirebaseHelper _firebaseHelper;
        private readonly ILevelEngine _levelEngine;

        private static List<User> Users { get; set; }

        public XpTracking(IFirebaseHelper firebaseHelper, ILevelEngine levelEngine)
        {
            _firebaseHelper = firebaseHelper;
            _levelEngine = levelEngine;

            Users = new List<User>();
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
            _levelEngine.CalculateLevel(user);

            if (user.Level > orginallevel)
            {
                try
                {
                    var eventItem = new LevelItem(user.Level, ActionType.Add);
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
            var user = Users.FirstOrDefault(x => x.UserName == userName);

            if (user == null)
            {
                user =  _firebaseHelper.GetUserAsync(userName).Result ?? new User {UserName = userName};

                var level = user.LevelHistory.OrderByDescending(x => x.DateTime).FirstOrDefault();

                user.Level = level?.Value ?? 0;
            }

            return user;
        }
    }
}
