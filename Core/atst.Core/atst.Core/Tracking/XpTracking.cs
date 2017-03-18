using System;
using atst.Core.Authentication.Entities;
using atst.Core.Helpers;

namespace atst.Core.Tracking
{
    public class XpTracking : IXpTracking
    {
        public bool ApplyTracking(string xpModelUserName, int xpModelXp, int integrationProvider)
        {
            var success = true;

            try
            {
                var eventItem = new EventItem(xpModelXp);

                var fbHelper = new FirebaseHelper("jyIAM1tnyy2k0y400mQgiNXKVG6jiO6lXqocQdqq", "https://all-the-small-things-7b52b.firebaseio.com/", "users", "integrations");

                var client = fbHelper.GetClient();
                fbHelper.CreateRecordAsync(integrationProvider, xpModelUserName.Replace('.', ','), eventItem, client);
            }
            catch (Exception e)
            {
                return false;
            }


            return true;
        }
    }
}
