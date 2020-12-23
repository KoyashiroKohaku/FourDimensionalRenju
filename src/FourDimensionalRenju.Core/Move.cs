using System;

namespace FourDimensionalRenju.Core
{
    public record Move
    {
        public Move(Player player, Point point)
    {
        Player = player;
        Point = point;
    }

    public Player Player { get; }
    public Point Point { get; }
    public DateTime DateTime { get; init; } = DateTime.Now;
}
}
