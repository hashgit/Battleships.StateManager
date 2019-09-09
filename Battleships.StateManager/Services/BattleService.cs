using System;
using System.Linq;
using Battleships.StateManager.Interfaces;
using Battleships.StateManager.Models;
using Battleship = Battleships.StateManager.Entities.Battleship;
using Plain = Battleships.StateManager.Entities.Plain;

namespace Battleships.StateManager.Services
{
    public interface IBattleService
    {
        void AddBattleship(IHaveBattleships plain, Battleship battleShip);
        AttackResult Shoot(ICanGetHit enemy, Position position);
    }

    public class BattleService : IBattleService
    {
        public void AddBattleship(IHaveBattleships plain, Battleship battleShip)
        {
            // do we need to check if two battleships can be placed adjacent?
            // not specified 
            plain.AddBattleship(battleShip);
        }

        public AttackResult Shoot(ICanGetHit enemy, Position position)
        {
            var result = enemy.TakeHit(position);

            if (result)
            {
                return AttackResult.Hit;
            }

            return AttackResult.Miss;
        }
    }
}