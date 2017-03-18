using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Models
{
   public class GitHubCommitJson
   {
      [JsonProperty("files")]
      public ICollection<GitHubCommitFileDetails> Files { get; set; }

      [JsonProperty("commit")]
      public GitHubCommitDetails CommitDetails { get; set; }
   }

   public class GitHubCommitDetails
   {
      [JsonProperty("author")]
      public GitHubAuthorDetails Author { get; set; }
   }

   public class GitHubAuthorDetails
   {
      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("email")]
      public string Email { get; set; }
   }

   public class GitHubCommitFileDetails
   {
      [JsonProperty("filename")]
      public string Filename { get; set; }

      [JsonProperty("modified")]
      // TODO make this into an enum
      public string Status { get; set; }

      [JsonProperty("raw_url")]
      public string RawUrl { get; set; }

      [JsonProperty("additions")]
      public int Additions { get; set; }

      [JsonProperty("deletions")]
      public int Deletions { get; set; }

      public int NumberOfModifications()
      {
         return Additions + Deletions;
      }
   }

}
