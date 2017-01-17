using Discord.Commands;
using System.Collections.Generic;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CommandsController : ICommandsController
    {
        #region Members

        private List<IModule> mModules = new List<IModule>();
        private CommandService mCommandService;

        #endregion

        public CommandsController(CommandService commandService)
        {
            mCommandService = commandService;
        }

        #region Public methods

        public void Add(IModule module)
        {
            mModules.Add(module);
        }

        public void Remove(IModule module)
        {
            mModules.Remove(module);
        }

        public void Run()
        {
            foreach (var module in mModules)
                module.Run(mCommandService);
        }

        #endregion
    }
}
