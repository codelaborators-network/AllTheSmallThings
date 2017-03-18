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
        private string _integrationsAlias { get; set; }

        public FirebaseHelper()
        {
            _appSecret = "jyIAM1tnyy2k0y400mQgiNXKVG6jiO6lXqocQdqq";
            _databaseUrl = "https://all-the-small-things-7b52b.firebaseio.com/";
            _integrationsAlias = "users";
            _usersDocumentAlias = "integrations";
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

        public async Task<string> CreateRecordAsync(int integrationId, string userName, EventItem eventItem)
        {
            var record = await Client()
              .Child(_integrationsAlias)
              .Child(integrationId.ToString())
              .Child(_usersDocumentAlias)
              .Child(userName.Replace(".", ","))
              .PostAsync(eventItem);

            return record.Key;
        }

        public async Task<User> GetUser(string userName)
        {
            //FILL ME IN BIG BOY!!


            return new User();
        }
    }
}