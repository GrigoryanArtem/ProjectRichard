using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRichard.Model.CivilizationV
{
    public class CivilizationGameRoom : IGameRoom
    {
        private List<Player> mPlayers = new List<Player>();
        private int mNumberOfPlayers;

        public List<Player> Players
        {
            get
            {
                return mPlayers;
            }
        }

        public int NumberOfPlayers
        {
            get
            {
               return mNumberOfPlayers;
            }
        }

        public CivilizationGameRoom(int numberOfPlayers)
        {
            if (numberOfPlayers < CivilizationConstants.MinPlayers ||
                numberOfPlayers > CivilizationConstants.MaxPlayers)
                throw new ArgumentException();

            mNumberOfPlayers = numberOfPlayers;
        }

        public void AddPlayer(Player player)
        {
            CivilizationPlayer civPlayer = (player as CivilizationPlayer);

            if(civPlayer == null || IsFormed() || mPlayers.Contains(player))
                throw new ArgumentException();

            mPlayers.Add(civPlayer);
        }

        public void RemovePlayer(Player player)
        {
            CivilizationPlayer civPlayer = (player as CivilizationPlayer);

            if (civPlayer == null || !mPlayers.Contains(civPlayer))
                throw new ArgumentException();

            mPlayers.Remove(civPlayer);
        }

        public bool IsFormed()
        {
            return mPlayers.Count == mNumberOfPlayers;
        }

        public bool Contains(string name)
        {
            return mPlayers
                .Where(player => player.Name == name)
                .Count() > 0;
        }
    }
}