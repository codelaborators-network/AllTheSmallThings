using Newtonsoft.Json;

namespace asti.GitHubHookApi.Models
{
   public class LintData
   {
      [JsonProperty("fileUrl")]
      public string FileUrl { get; set; }

      [JsonProperty("modCount")]
      public int ModCount { get; set; }

      [JsonProperty("username")]
      public string UserName { get; set; }
   }
}
