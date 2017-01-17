namespace ProjectRichard.Model.Bot.BotCommands
{
    public interface ICommandsController
    {
        void Run();
        void Add(IModule module);
        void Remove(IModule module);
    }
}
