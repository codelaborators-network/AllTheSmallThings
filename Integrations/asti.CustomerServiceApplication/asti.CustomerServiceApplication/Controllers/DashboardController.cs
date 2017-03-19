using asti.CustomerServiceApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asti.CustomerServiceApplication.Controllers
{
   public class DashboardController : Controller
   {
      // GET: Dashboard
      public ActionResult Index()
      {
         var users = ApiUrlGetHelper.PerformGetUsersAsync("stats/users/").Result;
         return View(users);
         
      }

      public ActionResult IndividualUser(string userEmailAddress)
      {
         var user = ApiUrlGetHelper.PerformGetUserAsync($"/stats/users/{userEmailAddress}").Result;
         return View(user);
      }
   }
}