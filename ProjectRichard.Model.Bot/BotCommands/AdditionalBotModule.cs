using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class AdditionalBotModule : DefaultModule
    {
        Random mRandom = new Random();

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
