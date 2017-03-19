using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asti.CustomerServiceApplication.Models
{
   public class UserClass
   {
      [JsonProperty("userName")]
      public string Username { get; set; }

      [JsonProperty("xp")]
      public int CurrentXp { get; set; }

      [JsonProperty("level")]
      public int Level { get; set; }

      [JsonProperty("xpHistory")]
      public List<XpHistory> XpHistory { get; set; }
   }

   public class XpHistory
   {
      [JsonProperty("value")]
      public int Value { get; set; }

      [JsonProperty("dateTime")]
      public DateTime DateTime { get; set; }
   }
}