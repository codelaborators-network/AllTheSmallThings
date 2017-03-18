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
   }

}
