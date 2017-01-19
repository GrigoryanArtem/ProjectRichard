using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectRichard.Data;
using Discord.Commands;
using System;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class Command
    {
        protected MethodInfo mMethod;
        protected IModule mParentModule;
        
        #region Properties

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public BotRoles Role { get; protected set; }

        public string ParameterName { get; protected set; }

        public ParameterType ParameterType { get; protected set; }

        #endregion

        public Command(IModule parentModule, MethodInfo commandMethod)
        {
            mParentModule = parentModule;
            mMethod = commandMethod;

            Init();
        }

        public virtual void Run(CommandService service)
        {
            var cmd = service.CreateCommand(Name).Description(Description);

            if(ParameterName != null)
                cmd.Parameter(ParameterName, ParameterType);

            cmd.Do(async (args) =>
                {
                    await args.Message.Delete();

                    if (GetRealRole(args.User.Roles) < Role) {
                        await args.Channel.SendMessage(CommandResources.PermissionDeniedMessege);
                        return;
                    }

                    Task function = (Task)mMethod.Invoke(mParentModule, new object[] { args });

                    try
                    {
                        await function;
                    }
                    catch(BotException exp)
                    {
                        await args.Channel.SendMessage(exp.Message);
                    }
                });
        }

        #region Private methods

        private BotRoles GetRealRole(IEnumerable<Discord.Role> roles)
        {
            BotRoles userRole = BotRoles.User;

            foreach (var role in roles) {
                BotRoles realRole = RoleManager.GetRealRole(role.Name);

                if (realRole > userRole)
                    userRole = realRole;
            }

            return userRole;
        }

        private void Init()
        {
            CommandAttribute atribute = (mMethod.GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute);

            Name = atribute.Name;
            Description = atribute.Description;
            Role = atribute.Role;
            ParameterName = atribute.ParameterName;
            ParameterType = atribute.ParameterType;
        }

        #endregion
    }
}
