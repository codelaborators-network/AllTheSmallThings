using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atst.Core.Authentication.Entities;
using Firebase.Database.Query;
using Newtonsoft.Json.Linq;

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
        private static string _profileAlias => "Profile";

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

        public async Task<string> CreateProfileRecordAsync(string userName, ProfileItem profileItem)
        {
            var record = await Client()
              .Child(_usersDocumentAlias)
              .Child(userName)
              .Child(_profileAlias)
              .PostAsync(profileItem);

            return record.Key;
        }

        public async Task<List<string>> GetUserNamesAsync()
        {
            List<string> userNames = new List<string>();

            var tasks = new List<Task>
            {
                Task.Factory.StartNew(
                    () =>
                    {
                        var userNamesTask = Client()
                            .Child(_usersDocumentAlias)
                            .OrderByKey()
                            .OnceAsync<Object>();

                        userNamesTask.Wait();

                        foreach(var user in userNamesTask.Result)
                        {
                            userNames.Add(user.Key);
                        }
                    }
                )
            };

            Task.WaitAll(tasks.ToArray());

            return userNames;
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
                                    new Game.Entities.GeneralEvent
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
                ),
                Task.Factory.StartNew(
                    () =>
                    {
                        var gearHistory = Client()
                            .Child(_usersDocumentAlias)
                            .Child(userRecord.UserName)
                            .Child(_gearEventAlias)
                            .OrderByKey()
                            .OnceAsync<GeneralItem>();

                        gearHistory.Wait();

                        userRecord.GearHistory =
                            gearHistory.Result.Select(
                                x =>
                                    new Game.Entities.GeneralEvent
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
                        var healthHistory = Client()
                            .Child(_usersDocumentAlias)
                            .Child(userRecord.UserName)
                            .Child(_healthEventAlias)
                            .OrderByKey()
                            .OnceAsync<GeneralItem>();

                        healthHistory.Wait();

                        userRecord.HealthHistory =
                            healthHistory.Result.Select(
                                x =>
                                    new Game.Entities.GeneralEvent
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