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
    public class FirebaseHelper
    {
        private string _appSecret { get; set; }
        private string _databaseUrl { get; set; }
        private string _usersDocumentAlias { get; set; }
        private string _integrationsAlias { get; set; }

        public FirebaseHelper(string appSecret, string databaseUrl, string usersDocumentAlias, string integrationsAlias)
        {
            _appSecret = appSecret;
            _databaseUrl = databaseUrl;
            _integrationsAlias = integrationsAlias;
            _usersDocumentAlias = usersDocumentAlias;
        }

        public FirebaseClient GetClient()
        {
            return new FirebaseClient(
              _databaseUrl,
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(_appSecret)
              });
        }

        public async Task<string> CreateRecordAsync(int integrationId, string userName, EventItem eventItem, FirebaseClient client)
        {
            var auth = _appSecret;
            var record = await client
              .Child(_integrationsAlias)
              .Child(integrationId.ToString())
              .Child(_usersDocumentAlias)
              .Child(userName.Replace(".", ","))
              .PostAsync(eventItem);
            return record.Key;
        }

        //public async Task<XPRecord> GetUserAsync(string userName, FirebaseClient client)
        //{
        //    var record = await client
        //      .Child("experiencePoints")
        //      .OrderByKey()
        //      .StartAt(userName)
        //      .OnceSingleAsync<XPRecord>();   
        //    return record;
        //}




    }
}