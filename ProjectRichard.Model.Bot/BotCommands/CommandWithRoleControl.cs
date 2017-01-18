using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CommandWithRoleControl : Command
    {
        private BotRoles mUserRole;

        public CommandWithRoleControl(BotRoles userRoles, IModule parentModule, MethodInfo commandMethod) : base(parentModule, commandMethod)
        {
            mUserRole = userRoles;
        }

        public override void Run(CommandService service)
        {
            base.Run(service);
        }
    }
}
