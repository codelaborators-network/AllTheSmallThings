using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asti.CustomerServiceApi.Models;
using asti.CustomerServiceApi.Helpers;
using Newtonsoft.Json;

namespace asti.CustomerServiceApi.Controllers
{
   [Route("/")]
   public class CustomerServiceController: Controller
   {
      [HttpGet]
      public string Get()
      {
         return "yo";
      }

      [HttpPost]
      public async Task<string> PostAsync(CustomerServiceResult result)
      {
         var jsonData = new CustomerServiceXpData
         {
            Username = result.Username,
            Xp = (result.TimeRemaining / 1000),
            IntegrationsProvider = 100,
            ActionType = 900
         };

         var response = await CustomerServiceHelper.PerformPostAsyc(JsonConvert.SerializeObject(jsonData));

         return response;
      }
   }
}
