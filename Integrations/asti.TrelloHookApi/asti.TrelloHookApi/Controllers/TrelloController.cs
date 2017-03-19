using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asti.TrelloHookApi.Helpers;

namespace asti.TrelloHookApi.Controllers
{
   [Route("/[controller]")]
   public class TrelloController : Controller
   {
      static string responseData;
      [HttpGet]
      public string Get()
      {
         if (string.IsNullOrEmpty(TrelloHelper.GetWebHooks().Result))
         {
            TrelloHelper.SetupWebhookForList(nameof(ListChangeEndPoint));
         }

         if (!string.IsNullOrEmpty(responseData))
         {
            return responseData;
         }
         return "lol, nope";
      }

      [HttpPost]
      public void ListChangeEndPoint([FromBody]string data)
      {
         responseData = data;
         // TODO parse data
      }

      [HttpGet]
      [Route("/Something")]
      public string GetResposeData()
      {
         return responseData;
      }
   }
}
