using System;
using System.Linq;
using Battleships.StateManager.Models;

namespace Battleships.StateManager
{
    public class BattleOrchestrator : IBattleGround
    {
        public GameResult Execute(BattleScenario scenario)
        {
            var plain = scenario.Plain;

            try
            {
                foreach (var battleship in scenario.Battleships)
                {
                    plain.AddBattleship(battleship);
                }

                var shotResults = scenario.ShotPoints?.Select(shotPoint => plain.GetShot(shotPoint)).ToList();

                var hasLost = plain.IsDestroyed();

                return new GameResult { AttackResults = shotResults, HasLost = hasLost };
            }
            catch (Exception e)
            {
                return new GameResult { IsError = true, Error = e.Message };
            }
        }
    }
}