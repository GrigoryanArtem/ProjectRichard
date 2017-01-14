using Discord;
using Discord.Commands;
using System;
using System.Text;

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
    }
}
