using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.StateManager.Models
{
    public class Battleship
    {
        public ShipPosition[] Positions { get; }
        private bool _isDestroyed;

        public Battleship(Position start, Position end)
        {
            var p = new List<ShipPosition>();
            if (start.X == end.X)
            {
                for (var i = start.Y; i <= end.Y; i++)
                {
                    p.Add(new ShipPosition { X = start.X, Y = i});
                }
            }
            else if (start.Y == end.Y)
            {
                for (var i = start.X; i <= end.X; i++)
                {
                    p.Add(new ShipPosition { X = i, Y = start.Y });
                }
            }
            else
            {
                throw new ArgumentException("Battleship should be 1xN or Nx1");
            }

            Positions = p.ToArray();
        }

        public bool TakeHit(Position position)
        {
            var pos = Positions.FirstOrDefault(p => p.X == position.X && p.Y == position.Y);
            if (pos != null)
            {
                pos.IsHit = true;
                _isDestroyed = Positions.Count(x => x.IsHit) == Positions.Length;
                return true;
            }

            return false;
        }

        public bool IsDestroyed()
        {
            return _isDestroyed;
        }
    }
}
