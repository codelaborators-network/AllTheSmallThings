using atst.Core.Authentication;
using atst.Core.Game.Experience;
using atst.Core.Game.Gear;
using atst.Core.Game.Leveling;
using atst.Core.Helpers;
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
            container.Register<IFirebaseHelper, FirebaseHelper>();
            container.Register<IXpAggregator, XpAggregator>();
            container.Register<ILevelEngine, DefaultLevelEngine>();
            container.Register<IArmoury, Armoury>();
        }
    }
}