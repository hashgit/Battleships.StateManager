using Battleships.StateManager.Models;

namespace Battleships.StateManager.Interfaces
{
    public interface ICanGetHit
    {
        bool IsDestroyed();
        bool TakeHit(Position position);
    }
}