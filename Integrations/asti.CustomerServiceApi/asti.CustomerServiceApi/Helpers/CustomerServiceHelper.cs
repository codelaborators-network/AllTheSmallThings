using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace asti.CustomerServiceApi.Helpers
{
   public static class CustomerServiceHelper
   {
      private static string ApiPostUrl = "http://abstractsausagefactory.azurewebsites.net/api/tracking/";

      public static async Task<string> PerformPostAsyc(string data)
      {
         using (var client = new HttpClient())
         {
            var responce = await client.PutAsync(ApiPostUrl, new StringContent(data, Encoding.UTF8, "application/json"));

            var responseData = await responce.Content.ReadAsStringAsync();

            return responseData;
         }
      }
   }
}
