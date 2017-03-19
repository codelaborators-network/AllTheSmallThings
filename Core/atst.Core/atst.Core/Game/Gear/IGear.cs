using System;

namespace atst.Core.Game.Gear
{
    public interface IGear
    {
        int Id { get; }
        string Name { get; }
        int Level { get; }
        int Defence { get; }
        int Attack { get; }
    }
}
