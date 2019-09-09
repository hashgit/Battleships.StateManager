using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.StateManager.Interfaces;
using Battleships.StateManager.Models;

namespace Battleships.StateManager.Entities
{
    public class Battleship : ICanGetHit
    {
        public ShipPosition[] Positions { get; }
        private bool _isDestroyed;

        public Battleship(Position start, Position end)
        {
            if (start.X < 0 || start.Y < 0 || end.X < 0 || end.Y < 0)
                throw new ArgumentException("Negative placements are not supported");

            var p = new List<ShipPosition>();
            if (start.X == end.X && start.Y < end.Y)
            {
                for (var i = start.Y; i <= end.Y; i++)
                {
                    p.Add(new ShipPosition { X = start.X, Y = i});
                }
            }
            else if (start.Y == end.Y && start.X < end.X)
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
                SetHitAt(pos);
                var isDestroyed = Positions.Count(x => x.IsHit) == Positions.Length;
                if (isDestroyed)
                {
                    SetDestroyed();
                }
                return true;
            }

            return false;
        }

        public bool IsDestroyed()
        {
            return _isDestroyed;
        }

        private void SetDestroyed()
        {
            _isDestroyed = true;
        }

        private void SetHitAt(ShipPosition pos)
        {
            pos.IsHit = true;
        }
    }
}
