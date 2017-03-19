using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atst.Core.Authentication.Entities;
using atst.Core.Helpers;
using atst.Core.Stats.Entities;
using Nancy;

namespace ApiRole.Modules.Stats
{
    public class StatsModule : NancyModule
    {
        private readonly IFirebaseHelper _firebaseHelper;
        public StatsModule(IFirebaseHelper firebaseHelper) : base("/api/stats/")
        {
            _firebaseHelper = firebaseHelper;
            Post["/users/"] = _ => GetUserDetails();
            Post["/users/{userName}"] = _ => GetUserDetails(_.userName);
        }

        private dynamic GetUserDetails()
        {
            var users = new List<User>();

            return Response.AsJson(users);
        }

        private dynamic GetUserDetails(string userName)
        {
            var user = (ExtendedUser) _firebaseHelper.GetUserAsync(userName).Result;
            return Response.AsJson(user);
        }
    }
}