using Microsoft.AspNetCore.Mvc;

namespace asti.GitHubHookApi.Controllers
{
   [Route("Tello")]
   public class TrelloController
   {
      [Route("/")]
      public string Get()
      {
         return "Guess again, sucker!";
      }

      [Route("/PushEndPoint")]
      public void PushEndPoint(string payload)
      {

      }
   }
}
