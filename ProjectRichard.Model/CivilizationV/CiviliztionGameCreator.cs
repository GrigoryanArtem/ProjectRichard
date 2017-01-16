using ProjectRichard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRichard.Model.CivilizationV
{
    public class CiviliztionGameCreator : IGameCreator
    {
        private Random mRandom = new Random();

        public IGameRoom CreateRoom(int numberOfPlayers)
        {
            return new CivilizationGameRoom(numberOfPlayers);
        }

        public Game CreateGame(IGameRoom room, string name)
        {
            List<Nation> nations = NationsManager.Instance.Nations;

            foreach(var player in room.Players)
            {
                CivilizationPlayer civPlayer = (player as CivilizationPlayer);

                nations.Remove(civPlayer.BannedNation);
            }

            nations = nations.OrderBy(x => mRandom.Next()).ToList();

            CivilizationGameBoard board = new CivilizationGameBoard();

            for (int i = 0, j = 0; i < room.Players.Count(); i++)
            {
                Nation[] nationsForPlayer = new Nation[CivilizationConstants.NumberOfNationsForPlayer];

                for (int k = 0; k < CivilizationConstants.NumberOfNationsForPlayer; k++, j++)
                    nationsForPlayer[k] = nations[j];

                board.Add(room.Players[i], nationsForPlayer);
            }

            return new CivilizationGame(name, board);
        }      
    }
}
