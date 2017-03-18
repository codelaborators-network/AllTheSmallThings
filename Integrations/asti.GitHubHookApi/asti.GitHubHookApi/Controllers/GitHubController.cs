using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using asti.GitHubHookApi.Models;
using asti.GitHubHookApi.Helpers;
using System.Linq;

namespace asti.GitHubHookApi.Controllers
{
   [Route("[controller]")]
   public class GitHubController
   {
      [HttpPost]
      public async void PushEndPoint([FromBody]string payload)
      {
         var pushDetails = JsonConvert.DeserializeObject<GitHubPushJson>(payload);
         var commitsString = await GitHubGetHelper.PerformGetAsync(pushDetails.CommitsApiUrl());
         var commits = JsonConvert.DeserializeObject<GitHubCommitJson>(commitsString);

         var jsFileUrls = commits.Files.Where(fi => fi.Filename.Contains(".js"));

         var jsonToSend = jsFileUrls.Select(fi => new LintData
         {
            FileUrl = fi.RawUrl,
            ModCount = fi.NumberOfModifications(),
            UserName = commits.CommitDetails.Author.Email
         }).ToList();

         LinterSingleton.Instance.SendFilesToLinter(jsonToSend);
      }
   }
}
