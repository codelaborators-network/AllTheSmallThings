using asti.TrelloHookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace asti.TrelloHookApi.Helpers
{
   public static class TrelloHelper
   {
      private static readonly string _apikey = "f2909050d4a906c93d97bebc750dbd5e";
      private static readonly string _token = "ac27828c5546f11de54c70f1461448457bdd673086aa0d34f68b76fa6797743a";
      private static readonly string _boardId = "YtX1qIsf";
      private static readonly string _listId = "58cadf414dec4ee9ed62ea14";
      private static readonly string _webHooksUrl = "https://api.trello.com/1/webhooks/";

      public static async Task<string> SetupWebhookForList(string callbackUrl)
      {
         // get all lists on board:
         // where is YtX1qIsf board id
         // board full id: 58ca664c13699a5eed32a4a6
         // https://api.trello.com/1/boards/YtX1qIsf/lists?key=f2909050d4a906c93d97bebc750dbd5e&token=ac27828c5546f11de54c70f1461448457bdd673086aa0d34f68b76fa6797743a

         // create new webhook for "Kit List" list (represents "done"):
         // POST
         // https://api.trello.com/1/webhooks/
         // Form data:
         // key:f2909050d4a906c93d97bebc750dbd5e
         // token: ac27828c5546f11de54c70f1461448457bdd673086aa0d34f68b76fa6797743a
         // description:A sample webhook created from the sandbox on a list
         // callbackURL:http://abstractsausagefactory-github.azurewebsites.net/PushEndPoint
         // idModel:58cadf414dec4ee9ed62ea14

         using (var client = new HttpClient())
         {
            var paramters = new TrelloNewWebHookParameters
            {
               Key = _apikey,
               Token = _token,
               Description = "A webhook for when cards move to the 'Kit List' list",
               CallbackUrl = $"http://abstractsausagefactory-trello.azurewebsites.net/{callbackUrl}",
               IdModel = _listId
            };

            var response = await client.PostAsync(_webHooksUrl, new StringContent(JsonConvert.SerializeObject(paramters), Encoding.UTF8, "application/json"));

            var responseData = await response.Content.ReadAsStringAsync();

            return responseData;
         }
      }

      public static async Task<string> GetWebHooks()
      {
         // 
         using (var client = new HttpClient())
         {
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri($"https://api.trello.com/1/members/me/tokens?webhooks=true&key={_apikey}&token={_token}"),
               Method = HttpMethod.Get
            };

            var response = await client.SendAsync(request);

            var taskData = response.Content.ReadAsStringAsync();

            return await taskData;
         }
      }
   }
}
