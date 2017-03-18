using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using atst.Core.Authentication.Entities;
using atst.Core.Helpers;

namespace atst.Core.Tracking
{
    public class XpTracking : IXpTracking
    {
        private readonly IFirebaseHelper _firebaseHelper;

        private static List<User> Users { get; set; }

        public XpTracking()
        {
            Users = new List<User>();
        }

        public bool ApplyTracking(string xpModelUserName, int xpModelXp, int integrationProvider)
        {
            var success = true;

            var user = GetUser(xpModelUserName);
            user.Xp += xpModelXp;


            try
            {
                var eventItem = new EventItem(xpModelXp, integrationProvider);
                
                _firebaseHelper.CreateXPRecordAsync(xpModelUserName.Replace('.', ','), eventItem);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private User GetUser(string userName)
        {
             return Users.FirstOrDefault(x => x.UserName == userName) ??
                        (_firebaseHelper.GetUser(userName).Result ?? 
                        new User { UserName = userName });
        }
    }
}
