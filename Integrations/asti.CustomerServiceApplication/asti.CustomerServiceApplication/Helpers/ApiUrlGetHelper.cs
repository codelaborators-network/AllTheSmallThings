using asti.CustomerServiceApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace asti.CustomerServiceApplication.Helpers
{
   public static class ApiUrlGetHelper
   {
      private static readonly string _apiDomain = "http://abstractsausagefactory.azurewebsites.net/api/";
      public static async Task<ICollection<UserClass>> PerformGetUsersAsync(string apiPath)
      {
         var fullUrl = $"{_apiDomain}{apiPath}";

         using (var client = new HttpClient())
         {
            try
            {
               var request = new HttpRequestMessage()
               {
                  RequestUri = new Uri(fullUrl),
                  Method = HttpMethod.Get
               };
               
               var response = client.SendAsync(request);

               var usersString = await response.Result.Content.ReadAsStringAsync();

               return JsonConvert.DeserializeObject<List<UserClass>>(usersString);
            }
            catch (HttpRequestException)
            {
               return new List<UserClass>();
            }
         }
      }

      public static async Task<UserClass> PerformGetUserAsync(string apiPath)
      {
         var fullUrl = $"{_apiDomain}{apiPath}";

         using (var client = new HttpClient())
         {
            try
            {
               var request = new HttpRequestMessage()
               {
                  RequestUri = new Uri(fullUrl),
                  Method = HttpMethod.Get
               };

               var response = client.SendAsync(request);

               var usersString = await response.Result.Content.ReadAsStringAsync();

               return JsonConvert.DeserializeObject<UserClass>(usersString);
            }
            catch (HttpRequestException)
            {
               return new UserClass();
            }
         }
      }
   }
}