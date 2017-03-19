using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atst.Core.Authentication.Entities;
using Firebase.Database.Query;

namespace atst.Core.Helpers
{
    public class FirebaseHelper : IFirebaseHelper
    {
        private string _appSecret { get; set; }
        private string _databaseUrl { get; set; }
        private string _usersDocumentAlias { get; set; }
        private static string _xpEventAlias => "XPEvents";
        private static string _levelEventAlias => "Levels";

        public FirebaseHelper()
        {
            _appSecret = "jyIAM1tnyy2k0y400mQgiNXKVG6jiO6lXqocQdqq";
            _databaseUrl = "https://all-the-small-things-7b52b.firebaseio.com/";
            _usersDocumentAlias = "users";
        }

        private FirebaseClient Client()
        {
            return new FirebaseClient(
              _databaseUrl,
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(_appSecret)
              });
        }

        public async Task<string> CreateXPRecordAsync(string userName, EventItem eventItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_xpEventAlias)
              .PostAsync(eventItem);
            return record.Key;
        }

        public async Task<string> CreateLevelRecordAsync(string userName, LevelItem levelItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_levelEventAlias)
              .PostAsync(levelItem);

            return record.Key;
        }

        public async Task<User> GetUser(string userName)
        {
            User userRecord = new User();
            userRecord.UserName = userName;

            var levelHistory = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_levelEventAlias)
              .OrderByKey()
              .OnceAsync<LevelItem>();

            userRecord.LevelHistory = levelHistory.Select(x=> new Game.Entities.Level { ActionType=x.Object.ActionType, DateTime = DateTime.Parse(x.Object.TimeStamp), Value = x.Object.Value  }).ToList();

            var xpHistory = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_xpEventAlias)
              .OrderByKey()
              .OnceAsync<EventItem>();

            userRecord.XpHistory = xpHistory.Select(x => new Game.Entities.Xp { ActionType = x.Object.ActionType, DateTime = DateTime.Parse(x.Object.TimeStamp), Value = x.Object.Value }).ToList();

            return userRecord;
        }
    }
}