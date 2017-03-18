using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atst.Core.Authentication;
using atst.Core.Tracking;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace ApiRole
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register<IUserRegistration,UserRegistration>();
            container.Register<IXpTracking,XpTracking>();
        }
    }
}