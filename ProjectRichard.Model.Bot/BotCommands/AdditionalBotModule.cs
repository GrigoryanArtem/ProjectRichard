using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class AdditionalBotModule : DefaultModule
    {
        Random mRandom = new Random();

        public AdditionalBotModule()
        {
            Add(new Command(CommandResources.TimeCommandName, CommandResources.TimeCommandDescription, Time));
            Add(new Command(CommandResources.RollCommandName, CommandResources.RollCommandDescription, Roll));
        }

        #region Commands

        private async Task Time(CommandEventArgs e)
        {
            await e.Channel.SendMessage(CreateTimeMessage());
        }

        private async Task Roll(CommandEventArgs e)
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
