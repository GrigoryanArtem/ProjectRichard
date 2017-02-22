using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class AdditionalBotModule : DefaultModule
    {
        private Random mRandom = new Random();

        #region Commands

        [Command(Name = CommandsConstants.TimeCommandName, Description = CommandsConstants.TimeCommandDescription)]
        public async Task Time(CommandEventArgs e)
        {
            await e.Channel.SendMessage(CreateTimeMessage());
        }

        [Command(Name = CommandsConstants.RollCommandName, Description = CommandsConstants.RollCommandDescription)]
        public async Task Roll(CommandEventArgs e)
        {
            int randomNumber = mRandom.Next(BotConstants.RollCommandMinValue, BotConstants.RollCommandMaxValue);

            await e.Channel.SendMessage(String.Format(CommandResources.RollCommandMessageFormat, e.User.Name, randomNumber));
        }

        [Command(Name = CommandsConstants.ClearCommandName, Description = CommandsConstants.ClearCommandDescription,
            Role = Data.BotRoles.Admin, ParameterName = CommandsConstants.ClearCommandParameterName)]
        public async Task Clear(CommandEventArgs e)
        {
            string userName = e.GetArg(CommandsConstants.ClearCommandParameterName);
            int count = 0;

            await e.Channel.DownloadMessages(limit: BotConstants.MessagesLimit);

            foreach (var message in e.Channel.Messages)
            {
                if (message.User.Name == userName)
                {
                    await message.Delete();
                    count++;
                }
            }

            await e.Channel.SendMessage(String.Format(CommandResources.RemoveMessage, count, userName));
        }

        #endregion

        #region Private methods

        private string CreateTimeMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(DateTime.Now.ToLongTimeString());
            sb.AppendLine(DateTime.Now.ToLongDateString());

            return sb.ToString();
        }

        #endregion
    }
}
