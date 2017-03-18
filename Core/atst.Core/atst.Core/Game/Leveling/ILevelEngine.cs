using atst.Core.Authentication.Entities;

namespace atst.Core.Game.Leveling
{
    public interface ILevelEngine
    {
        int CalculateLevel(User user);
    }
}