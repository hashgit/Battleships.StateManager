using System.Collections.Generic;

namespace Battleships.StateManager.Models
{
    public class BattleScenario
    {
        public Plain Plain { get; set; }

        public IEnumerable<Battleship> Battleships { get; set; }

        public IEnumerable<Position> ShotPoints { get; set; }
    }
}