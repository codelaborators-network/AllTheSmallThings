﻿using atst.Core.Authentication;
using atst.Core.Integration;
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
            container.Register<IXpTracking,XpTracking>();
            container.Register<IIntegrationProviders, IntegrationProviders>();
        }
    }
}