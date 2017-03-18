using System;
using System.Collections.Generic;
using System.Linq;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Leveling;
using atst.Core.Helpers;

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

        public bool ApplyTracking(string xpModelUserName, int xpModelXp, int integrationProvider)
        {
            var success = true;

            var user = GetUser(xpModelUserName);

            try
            {
                var eventItem = new EventItem(xpModelXp, integrationProvider);
                _firebaseHelper.CreateXPRecordAsync(xpModelUserName.Replace('.', ','), eventItem);
            }
            catch (Exception e)
            {
                return false;
            }

            user.Xp += xpModelXp;

            var orginallevel = user.Level;

            _levelEngine.CalculateLevel(user);

            if (user.Level > orginallevel)
            {
                try
                {
                    var eventItem = new EventItem(xpModelXp, integrationProvider);
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
                user = _firebaseHelper.GetUser(userName).Result ?? new User { UserName = userName };

                Users.Add(user);
            }

            _levelEngine.CalculateLevel(user);

            return user;
        }
    }
}
