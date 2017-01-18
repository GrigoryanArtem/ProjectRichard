using System.Threading.Tasks;
using Discord.Commands;
using System.Reflection;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class Command
    {
        protected MethodInfo mMethod;
        protected IModule mParentModule;
        
        #region Properties

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        #endregion

        public Command(IModule parentModule, MethodInfo commandMethod)
        {
            mParentModule = parentModule;
            mMethod = commandMethod;

            CommandAttribute atribute = (mMethod.GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute);

            Name = atribute.Name;
            Description = atribute.Description;
        }

        public virtual void Run(CommandService service)
        {
            service.CreateCommand(Name).
                    Description(Description).
                    Do(async (args) =>
                    {
                        await args.Message.Delete();

                        Task function = (Task)mMethod.Invoke(mParentModule, new object[] { args });
                        await function;
                    });
        }
    }
}
