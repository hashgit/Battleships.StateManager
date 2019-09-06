using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.StateManager.Models
{
    public class Plain
    {
        private readonly int _xaxis;
        private readonly int _yaxis;

        private readonly IList<Battleship> _battleships = new List<Battleship>();

        public Plain(int x, int y)
        {
            _xaxis = x;
            _yaxis = y;
        }

        public void AddBattleship(Battleship battleShip)
        {
            // do we need to check if two battleships can be placed adjacent?
            // not specified 

            // check if battleship can be added in this plain
            if (battleShip.Positions.Last().X > _xaxis - 1 || battleShip.Positions.Last().Y > _yaxis - 1)
                throw new ArgumentOutOfRangeException(nameof(battleShip), "Battleship is out of the bounds of plain");

            _battleships.Add(battleShip);
        }

        public AttackResult GetShot(Position position)
        {
            if (position.X > _xaxis || position.Y > _yaxis)
                throw new ArgumentOutOfRangeException(nameof(position), "Target attack point is out of range");

            // ensure only one ship takes the hit
            var battleship = _battleships.SingleOrDefault(b => b.TakeHit(position));
            if (battleship != null)
            {
                return AttackResult.Hit;
            }

            return AttackResult.Miss;
        }

        public bool IsDestroyed()
        {
            return _battleships.All(ship => ship.IsDestroyed());
        }
    }
}
