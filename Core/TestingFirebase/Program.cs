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
            int integrationId = 100;
            string emailAddress = "prjseal@gmail.com";
            int xp = 1;

            EventItem eventItem = new EventItem(xp, integrationId);

            FirebaseHelper fbHelper = new FirebaseHelper();

            var task = fbHelper.CreateXPRecordAsync(emailAddress.Replace(".", ","), eventItem);
            var result = task.Result;
        }
    }
}
