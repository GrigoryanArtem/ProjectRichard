using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class Command
    {
        protected Func<CommandEventArgs, Task> mFunction;

        #region Properties

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        #endregion

        public Command(string name, string description, Func<CommandEventArgs, Task> function)
        {
            Name = name;
            Description = description;
            mFunction = function;
        }

        public virtual async Task Run(CommandEventArgs args)
        {
            await mFunction(args);
        }
    }
}
