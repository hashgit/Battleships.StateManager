using System;
using Battleships.StateManager.Models;
using Xunit;

namespace Battleship.StateManager.Tests
{
    public class BattleshipTests
    {
        [Fact]
        public void CannotBuildDiagonalBattleship()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(9, 9));
            });
        }

        [Fact]
        public void CanBuildHorizontalBattleship()
        {
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(9, 0));
            Assert.Equal(10, battleship.Positions.Length);
        }

        [Fact]
        public void CanBuildVerticalBattleship()
        {
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(0, 9));
            Assert.Equal(10, battleship.Positions.Length);
        }
    }
}