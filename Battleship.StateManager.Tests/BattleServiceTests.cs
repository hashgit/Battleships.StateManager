using Battleships.StateManager.Interfaces;
using Battleships.StateManager.Models;
using Battleships.StateManager.Services;
using Moq;
using Xunit;

namespace Battleship.StateManager.Tests
{
    public class BattleServiceTests
    {
        [Fact]
        public void CanAddBattleshipToPlain()
        {
            var mockPlain = new Mock<IHaveBattleships>();
            var service = new BattleService();

            var battleship = new Battleships.StateManager.Entities.Battleship(new Position(1, 1), new Position(2,1));
            service.AddBattleship(mockPlain.Object, battleship);

            mockPlain.Verify(x => x.AddBattleship(battleship), Times.Once);
        }

        [Fact]
        public void CanHitEnemyPlain()
        {
            var mockPlain = new Mock<ICanGetHit>();

            var service = new BattleService();

            var position = new Position(2, 2);
            mockPlain.Setup(x => x.TakeHit(position)).Returns(true);
            var result = service.Shoot(mockPlain.Object, position);

            Assert.Equal(AttackResult.Hit, result);
            mockPlain.Verify(x => x.TakeHit(position), Times.Once);
        }

        [Fact]
        public void CannotHitEnemyPlainIfPositionIsWrong()
        {
            var mockPlain = new Mock<ICanGetHit>();

            var service = new BattleService();

            var position = new Position(2, 2);
            mockPlain.Setup(x => x.TakeHit(position)).Returns(false);
            var result = service.Shoot(mockPlain.Object, position);

            Assert.Equal(AttackResult.Miss, result);
            mockPlain.Verify(x => x.TakeHit(position), Times.Once);
        }
    }
}