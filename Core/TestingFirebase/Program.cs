using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using atst.Core.Helpers;
using atst.Core.Authentication.Entities;
using System.Web;

namespace TestingFirebase
{
    class Program
    {
        static void Main(string[] args)
        {
            //int integrationId = 100;
            //string emailAddress = "prjseal@gmail.com";
            //int xp = 1;

            //int level = 1;

            //EventItem eventItem = new EventItem(xp, integrationId, atst.Core.Game.Entities.ActionType.Add);
            //LevelItem levelItem = new LevelItem(level, atst.Core.Game.Entities.ActionType.Add);

            //FirebaseHelper fbHelper = new FirebaseHelper();

            //var xpTask = fbHelper.CreateXPRecordAsync(emailAddress.Replace(".", ","), eventItem);
            //var xpResult = xpTask.Result;

            //var levelTask = fbHelper.CreateLevelRecordAsync(emailAddress.Replace(".", ","), levelItem);
            //var levelResult = levelTask.Result;

            var user = fbHelper.GetUser("prjseal@gmail,com");
            var userResult = user.Result;
            var item = user;
        }
    }
}
