using System;
using System.Collections.Generic;
using Battleships.StateManager.Models;
using Battleships.StateManager.Services;

namespace Battleships.StateManager.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var scenario = new BattleScenario
            {
                Plain = new Plain { Xsize = 10, Ysize = 10 },
                Battleships = new List<Battleships.StateManager.Models.Battleship>
                {
                    new Battleships.StateManager.Models.Battleship { Start = new Position(5, 0), End = new Position(5, 9) }
                },
                ShotPoints = new List<Position>
                {
                    new Position(5, 0),
                    new Position(5, 1),
                    new Position(5, 2),
                    new Position(5, 3),
                    new Position(5, 4),
                    new Position(5, 5),
                    new Position(5, 6),
                    new Position(5, 7),
                    new Position(5, 8),
                    new Position(5, 9),
                }
            };

            var gameOrchestrator = new BattleOrchestrator(new BattleService());
            var result = gameOrchestrator.Execute(scenario);

            System.Console.WriteLine($"Enemy has {(result.HasLost ? "Lost" : "Not Lost")}");

            System.Console.ReadKey();
        }
    }
}
