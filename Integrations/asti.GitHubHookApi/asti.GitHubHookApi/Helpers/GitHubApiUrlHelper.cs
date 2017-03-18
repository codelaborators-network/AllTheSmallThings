using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Helpers
{
   public static class GitHubApiUrlHelper
   {
      static readonly string ClientId = "3bd4809a0cbbf371dd7b";
      static readonly string ClientSecret = "d49b128c173c339ce3111d21c252cbca5a89f4cc";

      public static Uri AddOathToApiCall(string requestUrl)
      {
         return new Uri(AddOathToApiUrl(requestUrl));
      }

      private static string AddOathToApiUrl(string requestUrl)
      {
         return $"{requestUrl}?client_id={ClientId}&client_secret={ClientSecret}";
      }
   }
}
