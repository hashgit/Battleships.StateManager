using System;
using System.Linq;
using Battleships.StateManager.Models;
using Battleships.StateManager.Services;
using Battleship = Battleships.StateManager.Entities.Battleship;
using Plain = Battleships.StateManager.Entities.Plain;

namespace Battleships.StateManager
{
    public class BattleOrchestrator : IBattleGround
    {
        private readonly IBattleService _battleService;

        public BattleOrchestrator(IBattleService battleService)
        {
            _battleService = battleService;
        }

        public GameResult Execute(BattleScenario scenario)
        {
            var plain = new Plain(scenario.Plain.Xsize, scenario.Plain.Ysize);

            try
            {
                foreach (var battleship in scenario.Battleships)
                {
                    _battleService.AddBattleship(plain, new Battleship(battleship.Start, battleship.End));
                }

                var shotResults = scenario.ShotPoints?.Select(shotPoint =>  _battleService.Shoot(plain, shotPoint)).ToList();

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