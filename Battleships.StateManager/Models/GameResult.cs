using System.Collections.Generic;

namespace Battleships.StateManager.Models
{
    public class GameResult
    {
        public IList<AttackResult> AttackResults { get; set; }
        public bool HasLost { get; set; }

        public bool IsError { get; set; }
        public string Error { get; set; }
    }
}