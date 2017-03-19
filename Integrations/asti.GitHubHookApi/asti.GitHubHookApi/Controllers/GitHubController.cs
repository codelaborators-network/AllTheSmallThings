using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using asti.GitHubHookApi.Models;
using asti.GitHubHookApi.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace asti.GitHubHookApi.Controllers
{
   [Route("GitHub")]
   public class GitHubController
   {
      [HttpGet]
      [Route("/")]
      public string Get()
      {
         return "lol, nope!";
      }

      [HttpPost]
      [Route("/PushEndPoint")]
      public async void PushEndPoint(string payload)
      {
         var pushDetails = JsonConvert.DeserializeObject<GitHubPushJson>(payload);
         var commitsString = await GitHubGetHelper.PerformGetAsync(pushDetails.CommitsApiUrl());
         var commits = JsonConvert.DeserializeObject<GitHubCommitJson>(commitsString);

         var jsFileUrls = commits.Files
               .Where(fi => fi.Filename.EndsWith(".js"))
               .Select(fi => new LintData
               {
                  FileUrl = fi.RawUrl,
                  ModCount = fi.NumberOfModifications(),
                  UserName = commits.CommitDetails.Author.Email
               }).ToList();

         LinterSingleton.Instance.SendFilesToLinter(jsFileUrls);
      }

      [HttpGet]
      [Route("/Test")]
      public string Test()
      {
         var commitJson = new GitHubCommitJson
         {
            CommitDetails = new GitHubCommitDetails
            {
               Author = new GitHubAuthorDetails
               {
                  Email = "someguy@someplace.com",
                  Name = "Some Guy"
               }
            },
            Files = new List<GitHubCommitFileDetails>
            {
               new GitHubCommitFileDetails
               {
                  Filename = "downwiththe.js",
                  RawUrl = "https://raw.githubusercontent.com/codelaborators-network/AllTheSmallThings/master/TheSickness/downwiththe.js",
                  Additions = 10,
                  Deletions = 12
               }
            }
         };

         var jsFileUrls = commitJson.Files
               .Where(fi => fi.Filename.Contains(".js"))
               .Select(fi => new LintData
               {
                  FileUrl = fi.RawUrl,
                  ModCount = fi.NumberOfModifications(),
                  UserName = commitJson.CommitDetails.Author.Email
               }).ToList();

         return LinterSingleton.Instance.SendFilesToLinter(jsFileUrls);
      }
   }
}
