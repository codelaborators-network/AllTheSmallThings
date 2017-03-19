namespace atst.Core.Game.Gear
{
    public interface IArmoury
    {
        IGear CreateRandomWeapon(int maxLevel = 1000, int minLevel = 1);
    }
}