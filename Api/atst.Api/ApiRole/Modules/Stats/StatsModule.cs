using System.Collections.Generic;
using atst.Core.Authentication.Entities;
using atst.Core.Game.Experience;
using atst.Core.Game.Leveling;
using atst.Core.Helpers;
using Nancy;

namespace ApiRole.Modules.Stats
{
    public class StatsModule : NancyModule
    {
        private readonly IFirebaseHelper _firebaseHelper;
        private readonly ILevelEngine _levelEngine;
        private readonly IXpAggregator _xpAggregator;

        public StatsModule(IFirebaseHelper firebaseHelper, ILevelEngine levelEngine, IXpAggregator xpAggregator) : base("/api/stats/")
        {
            _firebaseHelper = firebaseHelper;
            _levelEngine = levelEngine;
            _xpAggregator = xpAggregator;

            Get["/users/"] = _ => GetUserDetails();
            Get["/users/{userName}"] = _ => GetUserDetails(_.userName);
        }

        private dynamic GetUserDetails()
        {
            var users = new List<User>();
            var names = _firebaseHelper.GetUserNamesAsync().Result;

            foreach (var name in names)
            {
                var user = _firebaseHelper.GetUserAsync(name).Result;
                user.Xp = _xpAggregator.CalculateXp(user.XpHistory);
                _levelEngine.CalculateLevel(user);

                users.Add(user);
            }

            return Response.AsJson(users);
        }

        private dynamic GetUserDetails(string userName)
        {
            var user =  _firebaseHelper.GetUserAsync(userName).Result;
            user.Xp = _xpAggregator.CalculateXp(user.XpHistory);
            _levelEngine.CalculateLevel(user);
            return Response.AsJson(user);
        }
    }
}