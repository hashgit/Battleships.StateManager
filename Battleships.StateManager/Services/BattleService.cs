using System;
using System.Linq;
using Battleships.StateManager.Models;
using Battleship = Battleships.StateManager.Entities.Battleship;
using Plain = Battleships.StateManager.Entities.Plain;

namespace Battleships.StateManager.Services
{
    public interface IBattleService
    {
        void AddBattleship(Plain plain, Battleship battleShip);
        AttackResult Shoot(Plain enemy, Position position);
    }

    public class BattleService : IBattleService
    {
        public void AddBattleship(Plain plain, Battleship battleShip)
        {
            // do we need to check if two battleships can be placed adjacent?
            // not specified 
            plain.AddBattleship(battleShip);
        }

        public AttackResult Shoot(Plain enemy, Position position)
        {
            // ensure only one ship takes the hit
            if (position.X > enemy.Xaxis || position.Y > enemy.Yaxis)
                throw new ArgumentOutOfRangeException(nameof(position), "Target attack point is out of range");

            var result = enemy.Battleships.SingleOrDefault(b => TakeHit(b, position)) != null;

            if (result)
            {
                return AttackResult.Hit;
            }

            return AttackResult.Miss;
        }

        private bool TakeHit(Battleship battleship, Position position)
        {
            var pos = battleship.Positions.FirstOrDefault(p => p.X == position.X && p.Y == position.Y);
            if (pos != null)
            {
                battleship.SetHitAt(pos);
                var isDestroyed = battleship.Positions.Count(x => x.IsHit) == battleship.Positions.Length;
                if (isDestroyed)
                {
                    battleship.SetDestroyed();
                }
                return true;
            }

            return false;
        }
    }
}