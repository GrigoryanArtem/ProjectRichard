using Discord;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;
using ProjectRichard.Data;
using ProjectRichard.Model.CivilizationV;
using ProjectRichard.Model.Bot.BotCommands;

namespace ProjectRichard.Model.Bot
{
    public class DiscordBot
    {
        #region Members

        private DiscordClient mClient;
        private CommandService mCommands;
        private ICommandsController mController;

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

            mClient.UsingCommands(input =>
            {
                input.PrefixChar = BotConstants.PrefixChar;
                input.AllowMentionPrefix = true;
                input.HelpMode = HelpMode.Private;
            });

            mCommands = mClient.GetService<CommandService>();

            mController = new CommandsController(mCommands);

            mController.Add(new AdditionalBotModule());
            mController.Add(new CivilizationBotModule());
        }

        #endregion

        #region Public methods

        public void Start()
        {
            mController.Run();

            mClient.ExecuteAndWait(async () =>
                {
                    await mClient.Connect(BotToken, TokenType.Bot);
                });
        }

        #endregion
    }
}