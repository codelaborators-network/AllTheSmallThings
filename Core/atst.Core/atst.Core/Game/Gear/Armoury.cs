using System;
using System.Linq;

namespace atst.Core.Game.Gear
{
    public class Armoury : IArmoury
    {
        public IGear CreateRandomWeapon(int maxLevel, int minLevel)
        {
            var gearItem = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(g => !g.IsInterface && typeof(IGear).IsAssignableFrom(g)).Select(x=> new {item = x, id = Guid.NewGuid()}).OrderByDescending(x=>x.id).Select(x=>x.item).FirstOrDefault();

           return gearItem != null ? (IGear)Activator.CreateInstance(gearItem) : null;

        }
    }
}
