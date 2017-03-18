using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace ApiRole.Modules
{
    public class BaseModule : NancyModule
    {
        protected BaseModule(string modulePath) : base($"/api/{modulePath}/")
        {
        }
    }
}