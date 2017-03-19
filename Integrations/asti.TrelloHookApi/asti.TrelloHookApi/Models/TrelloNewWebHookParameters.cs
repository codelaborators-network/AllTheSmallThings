using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asti.TrelloHookApi.Models
{
   public class TrelloNewWebHookParameters
   {
      [JsonProperty("key")]
      public string Key { get; set; }

      [JsonProperty("token")]
      public string Token { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("callbackURL")]
      public string CallbackUrl { get; set; }

      [JsonProperty("idModel")]
      public string IdModel { get; set; }
   }
}
