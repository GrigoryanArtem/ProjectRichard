using Discord;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;
using ProjectRichard.Data;

namespace ProjectRichard.Model.Bot
{
    public class DiscordBot
    {
        #region Members

        private DiscordClient mClient;
        private CommandService mCommands;

        #endregion

        #region Properties

        public string BotToken { get; set; }

        #endregion

        #region Constructors

        public DiscordBot(EventHandler<LogMessageEventArgs> func)
        {
            mClient = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = func;
            });
        }

        #endregion

        #region Public methods

        public void Start()
        {
            mClient.UsingCommands(input =>
            {
                input.PrefixChar = BotConstants.PrefixChar;
                input.AllowMentionPrefix = true;
            });

            mCommands = mClient.GetService<CommandService>();

                
            mCommands.CreateCommand(BotConstants.TimeCommand).Do(async (e) =>
            {
                await e.Channel.SendMessage(GetTimeMessage());
            });

            mCommands.CreateCommand(BotConstants.UpdateCommand).Do((e) =>
            {
                NationsManager.Instance.Update();
            });

            mCommands.CreateCommand(BotConstants.GetNationInfoCommand).Parameter("name", ParameterType.Required).Do(async (e) =>
            {
                await FindNation(e);
            });


            mClient.ExecuteAndWait(async () =>
            {
                await mClient.Connect(BotToken, TokenType.Bot);
            });
        }

        #endregion

        #region Private methods

        private string GetTimeMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(DateTime.Now.ToLongTimeString());
            sb.AppendLine(DateTime.Now.ToLongDateString());

            return sb.ToString();
        }

        #endregion

        #region Commands

        private async Task FindNation(CommandEventArgs e)
        {
            Nation nation = NationsManager.Instance.FindByName(e.Args[0]);

            if(nation == null)
            {
                await e.User.SendMessage("Неверное название нации");
            }
            else
            {
                await e.User.SendMessage(NationInfo.Create(nation));
            }           
        }

        #endregion
    }
}
