using System.Collections.Generic;
using Battleships.StateManager.Entities;

namespace Battleships.StateManager.Interfaces
{
    public interface IHaveBattleships
    {
        IList<ICanGetHit> Battleships { get; set; }
        void AddBattleship(Battleship battleShip);
    }
}