using ProjectRichard.Data;
using System.Collections.Generic;

namespace ProjectRichard.Model.CivilizationV
{
    public class CivilizationGameBoard
    {
        private Dictionary<Player, Nation[]> mBoard = new Dictionary<Player, Nation[]>();

        public Dictionary<Player, Nation[]> Board
        {
            get
            {
                return mBoard;
            }
        }

        public void Add(Player player, Nation[] nations)
        {
            mBoard[player] = nations;
        }
    }
}
