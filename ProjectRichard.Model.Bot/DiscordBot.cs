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
        private CivilizationGameRoom room;
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
        }

        #endregion

        #region Public methods

        public void Start()
        {
            mController.Run();

            mCommands.CreateCommand(BotConstants.UpdateCommand).Do((e) =>
                {
                    NationsManager.Instance.Update();
                });

            mCommands.CreateCommand(BotConstants.GetNationInfoCommand).
                Parameter(BotConstants.GetNationInfoParameter, ParameterType.Required).
                Do(async (e) =>
                {
                    await FindNation(e);
                });

            mCommands.CreateCommand("nations").
                Do(async (e) =>
                {
                    await e.User.SendMessage(ShowAllNations());
                });

            mCommands.CreateCommand(BotConstants.CreateRoomCommand).
                Parameter(BotConstants.NumberOfPlayers, ParameterType.Required).
                Do(async (e) =>
                {
                    await CreateRoom(e);
                });

            mCommands.CreateCommand(BotConstants.JoinCommand).
                Parameter(BotConstants.BannedNation, ParameterType.Required).
                Do(async (e) =>
                {
                    await Join(e);
                });

            mCommands.CreateCommand(BotConstants.CreateGameCommand).
                Parameter(BotConstants.GameName, ParameterType.Required).
                Do(async (e) =>
                {
                    await CreateGame(e);
                });

            mClient.ExecuteAndWait(async () =>
                {
                    await mClient.Connect(BotToken, TokenType.Bot);
                });
        }

        #endregion

        #region Commands

        private async Task FindNation(CommandEventArgs e)
        {
            Nation nation = NationsManager.Instance.FindByName(e.GetArg(BotConstants.GetNationInfoParameter));

            await e.User.SendMessage((nation == null) ? BotMessages.FindNationError : NationInfo.Create(nation));   
        }

        private async Task Join(CommandEventArgs e)
        {
            try
            {
                Nation nation = NationsManager.Instance.FindByName(e.GetArg(BotConstants.BannedNation));

                if (nation == null)
                {
                    await e.Channel.SendMessage("nation is not exist");
                    return;
                }

                room.AddPlayer(new CivilizationPlayer(e.User.Name, nation));
                await e.Channel.SendMessage(String.Format("{0} зашел в комнату(1)\nМеста {1}/{2}", e.User.Name, room.Players.Count, room.NumberOfPlayers));
            }
            catch (Exception exp)
            {
                await e.Channel.SendMessage(String.Format("Ошибка: {0}", exp.Message));
            }
        }

        private async Task CreateRoom(CommandEventArgs e)
        {
            try
            {
                int numberOfPlayers = Convert.ToInt32(e.GetArg(BotConstants.NumberOfPlayers));

                room = new CivilizationGameRoom(numberOfPlayers);

                await e.Channel.SendMessage(String.Format("Комната создана id = 1\nМеста {0}/{1}", room.Players.Count, room.NumberOfPlayers));
            }
            catch(Exception exp)
            {
                await e.Channel.SendMessage(String.Format("Ошибка: {0}", exp.Message));
            }
        }

        private async Task CreateGame(CommandEventArgs e)
        {
            try
            {
                CiviliztionGameCreator creator = new CiviliztionGameCreator();
                CivilizationGame game = (creator.CreateGame(room, e.GetArg(BotConstants.GameName)) as CivilizationGame);

                await e.Channel.SendMessage(ShowBoard(game.Board));
            }
            catch (Exception exp)
            {
                await e.Channel.SendMessage(String.Format("Ошибка: {0}", exp.Message));
            }
        }

        private string ShowBoard(CivilizationGameBoard board)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(BotConstants.Separator);

            foreach (var row in board.Board)
            {
                stringBuilder.AppendLine(row.Key.Name);

                foreach (var nation in row.Value)
                {
                    stringBuilder.AppendLine(String.Format("\t- {0}", nation.Name));
                }
            }

            stringBuilder.AppendLine(BotConstants.Separator);

            return stringBuilder.ToString();
        }

        private string ShowAllNations()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(BotConstants.Separator);
            foreach (var nation in NationsManager.Instance.Nations)
            {
                sb.AppendLine(String.Format("{0} | {1}", nation.Evaluation, nation.Name));
            }

            sb.AppendLine(BotConstants.Separator);

            return sb.ToString();
        }

        #endregion
    }
}