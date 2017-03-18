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
            int integrationId = 1;
            string emailAddress = "prjseal@gmail.com";
            EventItem eventItem = new EventItem(10);

            FirebaseHelper fbHelper = new FirebaseHelper();

            var task = fbHelper.CreateRecordAsync(integrationId, emailAddress, eventItem);
            var result = task.Result;
        }
    }
}
