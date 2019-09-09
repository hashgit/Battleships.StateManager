using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.StateManager.Entities
{
    public class Plain
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
            if (battleShip.Positions.Last().X > Xaxis - 1 || battleShip.Positions.Last().Y > Yaxis - 1)
                throw new ArgumentOutOfRangeException(nameof(battleShip), "Battleship is out of the bounds of plain");

            Battleships.Add(battleShip);
        }

        public bool IsDestroyed()
        {
            return Battleships.All(ship => ship.IsDestroyed());
        }

        public IList<Battleship> Battleships { get; private set; } = new List<Battleship>();
    }
}
