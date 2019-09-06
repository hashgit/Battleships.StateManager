using System;
using Battleships.StateManager.Models;

namespace Battleships.StateManager
{
    public interface IBattleGround
    {
        GameResult Execute(BattleScenario scenario);
    }
}
