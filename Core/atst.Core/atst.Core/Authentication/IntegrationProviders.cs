using atst.Core.Integration;

namespace atst.Core.Authentication
{
    public class IntegrationProviders : IIntegrationProviders
    {
        public string[] GetProviderTypes()
        {
            return new []{ "GitHub", "Email", "Telephone", "SourceSafe", "SVN", "VSTS", "TFS-Onsite" };
        }
    }
}
