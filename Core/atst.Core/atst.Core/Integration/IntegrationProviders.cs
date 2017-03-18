namespace atst.Core.Integration
{
    public class IntegrationProviders : IIntegrationProviders
    {
        public string[] GetProviderTypes()
        {
            return new []{ "GitHub", "Email", "Telephone", "SourceSafe", "SVN", "VSTS", "TFS-Onsite" };
        }
    }
}
