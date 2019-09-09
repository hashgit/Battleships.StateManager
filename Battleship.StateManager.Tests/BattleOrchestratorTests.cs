using System.Collections.Generic;
using System.Linq;
using Battleships.StateManager;
using Battleships.StateManager.Models;
using Battleships.StateManager.Services;
using Xunit;

namespace Battleship.StateManager.Tests
{
    public class BattleOrchestratorTests
    {
        [Fact]
        public void WillShootTheShip()
        {
            var scenario = new BattleScenario
            {
                Plain = new Plain { Xsize = 10, Ysize = 10},
                Battleships = new List<Battleships.StateManager.Models.Battleship>
                {
                    new Battleships.StateManager.Models.Battleship { Start = new Position(5, 2), End = new Position(5, 6) }
                },
                ShotPoints = new List<Position>
                {
                    new Position(5, 4)
                }
            };

            var gameOrchestrator = new BattleOrchestrator(new BattleService());
            var result = gameOrchestrator.Execute(scenario);

            Assert.False(result.IsError);
            Assert.False(result.HasLost);
            Assert.Equal(AttackResult.Hit, result.AttackResults.First());
        }

        [Fact]
        public void WillDestroyTheShip()
        {
            var scenario = new BattleScenario
            {
                Plain = new Plain { Xsize = 10, Ysize = 10 },
                Battleships = new List<Battleships.StateManager.Models.Battleship>
                {
                    new Battleships.StateManager.Models.Battleship { Start = new Position(5, 2), End = new Position(5, 6) }
                },
                ShotPoints = new List<Position>
                {
                    new Position(5, 2),
                    new Position(5, 3),
                    new Position(5, 4),
                    new Position(5, 5),
                    new Position(5, 6)
                }
            };

            var gameOrchestrator = new BattleOrchestrator(new BattleService());
            var result = gameOrchestrator.Execute(scenario);

            Assert.False(result.IsError);
            Assert.True(result.HasLost);
            Assert.Equal(AttackResult.Hit, result.AttackResults.First());
        }
    }
}
