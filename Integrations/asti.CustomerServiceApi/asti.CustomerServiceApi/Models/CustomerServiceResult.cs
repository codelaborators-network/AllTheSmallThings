using Newtonsoft.Json;
using System;

namespace asti.CustomerServiceApi.Models
{
   public class CustomerServiceResult
   {
      [JsonProperty("username")]
      public string Username { get; set; }

      [JsonProperty("completed")]
      public bool Completed { get; set; }

      [JsonProperty("timeRemaining")]
      public int TimeRemaining { get; set; }
   }

   public class CustomerServiceXpData
   {
      [JsonProperty("UserName")]
      public string Username { get; set; }

      [JsonProperty("xp")]
      public int Xp { get; set; }

      [JsonProperty("IntegrationsProvider")]
      public int IntegrationsProvider { get; set; }

      [JsonProperty("actionType")]
      public int ActionType { get; set; }
   }
}
