using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public interface IModule
    {
        void Run(CommandService service);
    }
}
