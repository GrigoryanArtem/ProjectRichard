using ProjectRichard.Data;
using System.Collections.Generic;

namespace ProjectRichard.Model
{
    public abstract class Game
    {
        public string Name { get; protected set; }
        
        public List<Player> Players { get; protected set; }

        public Map GameMap { get; protected set; }

        public Game()
        {
            Players = new List<Player>();
        }

        public Game(string name) : this()
        {
            Name = name;
        }

        public Game(string name, List<Player> players) : this(name)
        {
            Players = players;
        }
    }
}