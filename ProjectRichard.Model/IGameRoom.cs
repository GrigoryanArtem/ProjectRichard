using System.Collections.Generic;

namespace ProjectRichard.Model
{
    public interface IGameRoom
    {
        int NumberOfPlayers { get; }
        List<Player> Players { get; }
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
        bool IsFormed();
    }
}