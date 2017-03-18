using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using asti.GitHubHookApi.Models;
using asti.GitHubHookApi.Helpers;

namespace asti.GitHubHookApi.Controllers
{
   [Route("[controller]")]
   public class GitHubController
   {
      [HttpPost]
      public async void Push(string payload)
      {
         var pushDetails = JsonConvert.DeserializeObject<GitHubPushJson>(payload);
         var commitsString = await GitHubGetHelper.PerformGetAsync(pushDetails.CommitsApiUrl());
         var commits = JsonConvert.DeserializeObject<GitHubCommitJson>(commitsString);

         // TODO: send commits to Zac's linter
      }
   }
}
