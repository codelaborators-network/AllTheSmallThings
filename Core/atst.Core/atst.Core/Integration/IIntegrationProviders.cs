using System.Collections.Generic;

namespace atst.Core.Integration
{
    public interface IIntegrationProviders
    {
        Dictionary<string, int> GetProviderTypes();
    }
}