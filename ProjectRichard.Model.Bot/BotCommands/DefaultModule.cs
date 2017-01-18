using System.Collections.Generic;
using Discord.Commands;
using System.Linq;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public abstract class DefaultModule : IModule
    {
        #region Members

        protected List<Command> mCommands = new List<Command>();

        #endregion

        public DefaultModule()
        {
            AddCommands();
        }

        public void Run(CommandService service)
        {
            foreach (var command in mCommands)
                command.Run(service);
        }

        #region Protected methods

        protected void AddCommands()
        {
            var methods = this.GetType().GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0)
                .ToArray();

            foreach (var method in methods)
                mCommands.Add(new Command(this, method));
        }

        #endregion
    }
}
