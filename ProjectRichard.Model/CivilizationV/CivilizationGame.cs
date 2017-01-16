namespace ProjectRichard.Model.CivilizationV
{
    public class CivilizationGame : Game
    {
        public CivilizationGameBoard Board { get; private set; }

        public CivilizationGame(string name, CivilizationGameBoard board) : base(name)
        {
            foreach (Player player in board.Board.Keys)
                Players.Add(player);

            Board = board;
        }
    }
}
