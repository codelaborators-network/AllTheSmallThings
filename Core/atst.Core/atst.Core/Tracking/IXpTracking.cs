using atst.Core.Game.Entities;
using atst.Core.Integration;

namespace atst.Core.Tracking
{
    public interface IXpTracking
    {
        bool ApplyTracking(string xpModelUserName, int xpModelXp, IntegrationsProviderTypes integrationProvider, ActionType actionType);
    }
}