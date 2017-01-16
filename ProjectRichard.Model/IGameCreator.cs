 namespace ProjectRichard.Model
{
    public interface IGameCreator
    {
        IGameRoom CreateRoom(int numberOfPlayers);

        Game CreateGame(IGameRoom room, string name);
    }
}