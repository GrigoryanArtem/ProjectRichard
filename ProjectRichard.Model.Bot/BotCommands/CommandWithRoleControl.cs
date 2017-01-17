using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CommandWithRoleControl : Command
    {
        private BotRoles mUserRole;

        public CommandWithRoleControl(string name, string description, 
            BotRoles userRole, Func<CommandEventArgs, Task> function) : base(name, description, function)
        {
            mUserRole = userRole;
        }

        public override async Task Run(CommandEventArgs args)
        {
            // TO DO
            // Chek user role

            await base.Run(args);
        }
    }
}
