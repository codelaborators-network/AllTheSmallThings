using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Helpers
{
   public static class GitHubGetHelper
   {
      public static async Task<string> PerformGetAsync(string urlToResource)
      {
         var fullUrlWithAuth = GitHubApiUrlHelper.AddOathToApiCall(urlToResource);

         using (var client = new HttpClient())
         {
            try
            {
               var request = new HttpRequestMessage()
               {
                  RequestUri = fullUrlWithAuth,
                  Method = HttpMethod.Get
               };

               client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

               var response = await client.SendAsync(request);

               var taskData = response.Content.ReadAsStringAsync();

               return await taskData;
            }
            catch (HttpRequestException e)
            {
               return String.Empty;
            }
         }
      }
   }
}
