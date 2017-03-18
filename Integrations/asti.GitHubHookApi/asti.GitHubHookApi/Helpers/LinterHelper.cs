using asti.GitHubHookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Helpers
{
   public class LinterHelper
   {
      private static string LinterPostUrl = "/lint";

      public static async void PerformPostAsyc(string data)
      {
         var fullUrlWithAuth = GitHubApiUrlHelper.AddOathToApiCall(LinterPostUrl);

         using (var client = new HttpClient())
         {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("", data)
            });

            var responce = await client.PostAsync(LinterPostUrl, content);
         }
      }
   }
}
