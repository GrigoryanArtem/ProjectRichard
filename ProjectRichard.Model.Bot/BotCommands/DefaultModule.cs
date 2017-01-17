using System.Collections.Generic;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public abstract class DefaultModule : IModule
    {
        #region Members

        private List<Command> mCommands = new List<Command>();

        #endregion

        public void Run(CommandService service)
        {
            foreach (var command in mCommands)
            {
                service.CreateCommand(command.Name).
                    Description(command.Description).
                    Do(async (e) =>
                    {
                        await e.Message.Delete();
                        await command.Run(e);
                    });
            }
        }

        #region Protected methods

        protected void Add(Command command)
        {
            mCommands.Add(command);
        }

        protected void Remove(Command command)
        {
            mCommands.Remove(command);
        }

        #endregion
    }
}
