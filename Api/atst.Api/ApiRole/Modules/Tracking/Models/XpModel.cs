using atst.Core.Game.Entities;
using atst.Core.Integration;

namespace ApiRole.Modules.Tracking.Models
{
    public class XpModel
    {
        public string UserName { get; set; }
        public int Xp { get; set; }
        public IntegrationsProviderTypes IntegrationsProvider { get; set; }
        public ActionType ActionType { get; set; }
    }
}