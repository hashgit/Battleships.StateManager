using System;
using Battleships.StateManager.Models;
using Xunit;
using Plain = Battleships.StateManager.Entities.Plain;

namespace Battleship.StateManager.Tests
{
    public class PlainTests
    {
        [Fact]
        public void CanAddBattleship()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(0, 9));
            plain.AddBattleship(battleship);

            Assert.Equal(1, plain.Battleships.Count);
        }

        [Fact]
        public void CannotAddBattleshipIfBiggerThanPlan()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(0, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => plain.AddBattleship(battleship));
        }

        [Fact]
        public void CannotAddBattleshipIfSmallerThanPlan()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(0, 8));
            Assert.Throws<ArgumentOutOfRangeException>(() => plain.AddBattleship(battleship));
        }

        [Fact]
        public void CanAddBattleshipHorizontal()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(9, 0));
            plain.AddBattleship(battleship);

            Assert.Equal(1, plain.Battleships.Count);
        }

        [Fact]
        public void CannotAddHorizontalBattleshipIfBiggerThanPlan()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(10, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => plain.AddBattleship(battleship));
        }

        [Fact]
        public void CannotAddHorizontalBattleshipIfSmallerThanPlan()
        {
            var plain = new Plain(10, 10);
            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(0, 0), new Position(8, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => plain.AddBattleship(battleship));
        }
    }
}