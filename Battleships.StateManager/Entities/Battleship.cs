using System;
using System.Collections.Generic;
using Battleships.StateManager.Models;

namespace Battleships.StateManager.Entities
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

        public bool IsDestroyed()
        {
            return _isDestroyed;
        }

        public void SetDestroyed()
        {
            _isDestroyed = true;
        }

        public void SetHitAt(ShipPosition pos)
        {
            pos.IsHit = true;
        }
    }
}
