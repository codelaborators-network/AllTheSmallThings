using asti.GitHubHookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Helpers
{
   public sealed class LinterSingleton
   {
      private static readonly LinterSingleton instance = new LinterSingleton();

      static LinterSingleton()
      {

      }

      private LinterSingleton()
      {
      }

      public static LinterSingleton Instance
      {
         get
         {
            return instance;
         }
      }

      public async void SendFilesToLinter(LintData fileData)
      {
         var json = JsonConvert.SerializeObject(fileData);

         LinterHelper.PerformPostAsyc(json);
      }
   }
}
