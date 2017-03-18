using atst.Core.Integration;
using Nancy;

namespace ApiRole.Modules.Integrations
{
    public class IntegrationsModule : NancyModule
    {
        private readonly IIntegrationProviders _integrationProviders;

        public IntegrationsModule(IIntegrationProviders integrationProviders) : base("/api/integration/")
        {
            _integrationProviders = integrationProviders;

            Get["providers"] = _ => GetProviderTypes();
        }

        private dynamic GetProviderTypes()
        {
            return Response.AsJson(_integrationProviders.GetProviderTypes(), HttpStatusCode.OK);
        }
    }
}