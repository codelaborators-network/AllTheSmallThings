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
        private string _appSecret => "jyIAM1tnyy2k0y400mQgiNXKVG6jiO6lXqocQdqq";
        private string _databaseUrl => "https://all-the-small-things-7b52b.firebaseio.com/";
        private string _usersDocumentAlias => "users";
        private static string _xpEventAlias => "XPEvents";
        private static string _levelEventAlias => "Levels";
        private static string _gearEventAlias => "Gear";
        private static string _healthEventAlias => "Health";

        public FirebaseHelper()
        {

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

        public async Task<string> CreateLevelRecordAsync(string userName, GeneralItem generalItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_levelEventAlias)
              .PostAsync(generalItem);

            return record.Key;
        }

        public async Task<string> CreateGearRecordAsync(string userName, GeneralItem generalItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_gearEventAlias)
              .PostAsync(generalItem);

            return record.Key;
        }

        public async Task<string> CreateHealthRecordAsync(string userName, GeneralItem generalItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_healthEventAlias)
              .PostAsync(generalItem);

            return record.Key;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            User userRecord = new User
            {
                UserName = userName.Replace('.', ',')
            };

            var tasks = new List<Task>
            {
                Task.Factory.StartNew(
                    () =>
                    {
                        var levelHistory = Client()
                            .Child(_usersDocumentAlias)
                            .Child(userRecord.UserName)
                            .Child(_levelEventAlias)
                            .OrderByKey()
                            .OnceAsync<GeneralItem>();

                        levelHistory.Wait();

                        userRecord.LevelHistory =
                            levelHistory.Result.Select(
                                x =>
                                    new Game.Entities.Level
                                    {
                                        ActionType = x.Object.ActionType,
                                        DateTime = DateTime.Parse(x.Object.TimeStamp),
                                        Value = x.Object.Value
                                    }).ToList();
                    }
                ),
                Task.Factory.StartNew(
                    () =>
                    {
                        var xpHistory = Client()
                            .Child(_usersDocumentAlias)
                            .Child(userRecord.UserName)
                            .Child(_xpEventAlias)
                            .OrderByKey()
                            .OnceAsync<EventItem>();

                        xpHistory.Wait();

                        userRecord.XpHistory =
                            xpHistory.Result.Select(
                                x =>
                                    new Game.Entities.Xp
                                    {
                                        ActionType = x.Object.ActionType,
                                        DateTime = DateTime.Parse(x.Object.TimeStamp),
                                        Value = x.Object.Value
                                    }).ToList();
                    }
                )
            };



            Task.WaitAll(tasks.ToArray());

            return userRecord;
        }
    }
}