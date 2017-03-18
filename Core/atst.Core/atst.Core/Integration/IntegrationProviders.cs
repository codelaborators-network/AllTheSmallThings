using System;
using System.Collections;
using System.Collections.Generic;

namespace atst.Core.Integration
{
    public class IntegrationProviders : IIntegrationProviders
    {
        public Dictionary<string, int> GetProviderTypes()
        {
            var names = Enum.GetNames(typeof(IntegrationsProviderTypes));

            var providers = new Dictionary<string, int>();

            foreach (var name in names)
            {
                providers.Add(name, (int)Enum.Parse(typeof(IntegrationsProviderTypes), name));
            }

            return providers;
        }
    }
}
