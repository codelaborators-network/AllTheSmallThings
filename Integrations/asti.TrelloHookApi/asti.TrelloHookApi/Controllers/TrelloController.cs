using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace asti.TrelloHookApi.Controllers
{
   [Route("/[controller]")]
   public class TrelloController : Controller
   {
      [HttpGet]
      public string Get()
      {
         return "lol, nope";
      }
   }
}
