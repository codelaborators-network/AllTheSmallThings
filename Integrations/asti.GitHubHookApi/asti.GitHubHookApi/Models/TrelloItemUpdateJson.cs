using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asti.GitHubHookApi.Models
{
   public class TrelloItemUpdateJson
   {
      [JsonProperty("action")]
      public TrelloItemAction Action { get; set; }
   }

   public class TrelloItemAction
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("idMemberCreator")]
      public string IdMemberCreator { get; set; }

      [JsonProperty("data")]
      public TrelloItemActionData Data { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("date")]
      public string Date { get; set; }

      [JsonProperty("memberCreator")]
      public TrelloItemMemberCreator MemberCreator { get; set; }
   }

   public class TrelloItemActionData
   {
      [JsonProperty("board")]
      public TrelloItemActionDataBoard Board { get; set; }

      [JsonProperty("card")]
      public TrelloItemActionDataCard Card {get; set; }

      [JsonProperty("voted")]
      public bool Voted { get; set; }
   }

   public class TrelloItemActionDataBoard
   {
      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("id")]
      public string Id { get; set; }
   }

   public class TrelloItemActionDataCard
   {
      [JsonProperty("idShort")]
      public string IdShort { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("id")]
      public string Id { get; set; }
   }

   public class TrelloItemMemberCreator
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("avatarHash")]
      public string AvatarHash { get; set; }

      [JsonProperty("fullName")]
      public string FullName { get; set; }

      [JsonProperty("initials")]
      public string Initials { get; set; }

      [JsonProperty("username")]
      public string Username { get; set; }
   }

   /// <summary>
   /// Represents the Items which has been updated
   /// </summary>
   public class TrelloItemModel
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("closed")]
      public bool Closed { get; set; }

      [JsonProperty("idOrganization")]
      public string IdOrganisation { get; set; }

      [JsonProperty("pinned")]
      public bool Pinned { get; set; }

      [JsonProperty("url")]
      public string Url { get; set; }

   }
}
