using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.StateManager.Interfaces;
using Battleships.StateManager.Models;

namespace Battleships.StateManager.Entities
{
    public class Plain : IHaveBattleships, ICanGetHit
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }

        public Plain(int x, int y)
        {
            Xaxis = x;
            Yaxis = y;
        }

        public void AddBattleship(Battleship battleShip)
        {
            // check if battleship can be added in this plain
            if (!(battleShip.Positions.First().X == 0 && battleShip.Positions.Last().X == Xaxis - 1)
                && !(battleShip.Positions.First().Y == 0 && battleShip.Positions.Last().Y == Yaxis - 1))
                throw new ArgumentOutOfRangeException(nameof(battleShip), "Battleship is out of the bounds of plain");

            Battleships.Add(battleShip);
        }

        public bool TakeHit(Position position)
        {
            // ensure only one ship takes the hit
            if (position.X > Xaxis || position.Y > Yaxis)
                throw new ArgumentOutOfRangeException(nameof(position), "Target attack point is out of range");

            return Battleships.SingleOrDefault(b => b.TakeHit(position)) != null;
        }

        public bool IsDestroyed()
        {
            return Battleships.All(ship => ship.IsDestroyed());
        }

        public IList<ICanGetHit> Battleships { get; set; } = new List<ICanGetHit>();
    }
}
