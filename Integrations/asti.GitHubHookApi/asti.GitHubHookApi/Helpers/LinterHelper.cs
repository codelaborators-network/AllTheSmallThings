using asti.GitHubHookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Helpers
{
   public class LinterHelper
   {
      private static string LinterPostUrl = "https://atst-eslint-integration.herokuapp.com/lint";

      public static async Task<string> PerformPostAsyc(string data)
      {
         using (var client = new HttpClient())
         {
            var responce = await client.PostAsync(LinterPostUrl, new StringContent(data, Encoding.UTF8, "application/json"));

            var responseData = await responce.Content.ReadAsStringAsync();

            return responseData;
         }
      }
   }
}
