using Discord.Commands;
using ProjectRichard.Data;
using ProjectRichard.Model.CivilizationV;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CivilizationBotModule : DefaultModule
    {
        private CiviliztionGameCreator mGameCreator = new CiviliztionGameCreator();
        IGameRoom mRoom;

        #region Commands

        [Command(Name = CommandsConstants.CreateRoomCommandName, Description = CommandsConstants.CreateRoomCommandDescription,
            Role = Data.BotRoles.Moderator ,ParameterName = CommandsConstants.CreateRoomCommandParameterName)]
        public async Task CreateRoom(CommandEventArgs e)
        {
            int numberOfPlayers = Convert.ToInt32(e.GetArg(CommandsConstants.CreateRoomCommandParameterName));

            mRoom = mGameCreator.CreateRoom(numberOfPlayers);

            await e.Channel.SendMessage(String.Format(CommandResources.RoomCreatedMessage));
        }

        [Command(Name = CommandsConstants.RoomInfoCommandName, Description = CommandsConstants.RoomInfoCommandDescription)]
        public async Task RoomInfo(CommandEventArgs e)
        {
            if (mRoom == null)
                throw new BotException(CommandResources.RoomWasNotCreated);

            await e.Channel.SendMessage(RoomInfo());
        }

        [Command(Name = CommandsConstants.JoinCommandName, Description = CommandsConstants.JoinCommandDescription)]
        public async Task Join(CommandEventArgs e)
        {
            if(mRoom.Contains(e.User.Name))
                throw new BotException(CommandResources.PlayerContains);

            mRoom.AddPlayer(new CivilizationPlayer(e.User.Name));

            await e.Channel.SendMessage(String.Format(CommandResources.AddedPlayerMessage,
                e.User.Name, mRoom.Players.Count(), mRoom.NumberOfPlayers));
        }

        [Command(Name = CommandsConstants.ExitCommandName, Description = CommandsConstants.ExitCommandDescription)]
        public async Task Exit(CommandEventArgs e)
        {
            if (!mRoom.Contains(e.User.Name))
                throw new BotException(CommandResources.PlayerNotContains);

            var playerForRemove = mRoom.Players
                .Where(player => player.Name == e.User.Name)
                .First();

            mRoom.RemovePlayer(playerForRemove);

            await e.Channel.SendMessage(String.Format(CommandResources.RemovedPlayerMessage,
                e.User.Name, mRoom.Players.Count(), mRoom.NumberOfPlayers));
        }

        [Command(Name = CommandsConstants.BanCommandName, Description = CommandsConstants.BanCommandDescription,
            ParameterName = CommandsConstants.BanCommandParameterName)]
        public async Task Ban(CommandEventArgs e)
        {
            if (!mRoom.Contains(e.User.Name))
                throw new BotException(CommandResources.PlayerNotContains);

            Nation banNation = FinNation(e.GetArg(CommandsConstants.BanCommandParameterName));

            if (mRoom.Players
                .Where(player => (player as CivilizationPlayer).BannedNation == banNation)
                .Count() > 0)
                throw new BotException(CommandResources.NationIsBanned);

            (mRoom.Players.Where(player => player.Name == e.User.Name).First() as CivilizationPlayer).BannedNation = banNation;
            await e.Channel.SendMessage(String.Format(CommandResources.BannedPlayerMessage,
                e.User.Name, banNation.Name));
        }

        [Command(Name = CommandsConstants.NationCommandName, Description = CommandsConstants.NationCommandDescription,
            ParameterName = CommandsConstants.NationCommandParameterName)]
        public async Task Nation(CommandEventArgs e)
        {
            Nation nation = FinNation(e.GetArg(CommandsConstants.NationCommandParameterName));

            await e.User.SendMessage(NationInfo.Create(nation));
        }

        [Command(Name = CommandsConstants.NationsCommandName, Description = CommandsConstants.NationsCommandDescription)]
        public async Task Nations(CommandEventArgs e)
        {
            await e.User.SendMessage(CreateNationsTable());
        }

        [Command(Name = CommandsConstants.CreateGameCommandName, Description = CommandsConstants.CreateGameCommandDescription,
            Role = Data.BotRoles.Moderator, ParameterName = CommandsConstants.CreateGameCommandParameterName)]
        public async Task CreateGame(CommandEventArgs e)
        {
            if (!mRoom.IsFormed())
                throw new BotException(CommandResources.RoomIsNotFormed);

            CiviliztionGameCreator creator = new CiviliztionGameCreator();
            CivilizationGame game = (creator.CreateGame(mRoom,
                e.GetArg(CommandsConstants.CreateGameCommandParameterName)) as CivilizationGame);

            await e.Channel.SendMessage(ShowBoard(game));
        }

        #endregion

        #region Private methods

        private string RoomInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BotConstants.Separator);

            stringBuilder.AppendFormat(CommandResources.RoomInfoHeader, mRoom.Players.Count, mRoom.NumberOfPlayers);
            stringBuilder.AppendLine();

            stringBuilder.AppendLine(CommandResources.PlayersInfoHeader);

            foreach (var player in mRoom.Players)
            {
                stringBuilder.AppendFormat(CommandResources.PlayerInfoFormat, player.Name);

                if ((player as CivilizationPlayer).BannedNation != null)
                    stringBuilder.AppendFormat(CommandResources.BanInfoFormat, (player as CivilizationPlayer).BannedNation.Name);

                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine(BotConstants.Separator);

            return stringBuilder.ToString();
        }

        private string ShowBoard(CivilizationGame game)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(BotConstants.Separator);

            stringBuilder.AppendLine(game.Name);
            stringBuilder.AppendLine();

            foreach (var row in game.Board.Board)
            {
                stringBuilder.AppendLine(row.Key.Name);

                foreach (var nation in row.Value)
                    stringBuilder.AppendLine(String.Format("\t- {0}", nation.Name));
            }

            stringBuilder.AppendLine(BotConstants.Separator);

            return stringBuilder.ToString();
        }

        private Nation FinNation(string name)
        {
            Nation nation = NationsManager.Instance.FindByName(name);

            if (nation == null)
                throw new BotException(CommandResources.FindNationError);

            return nation;
        }

        private string CreateNationsTable()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var nation in NationsManager.Instance.Nations)
                stringBuilder.AppendLine(
                    String.Format(CommandResources.ShortNationInfoFormat, nation.Name, nation.Evaluation));

            return stringBuilder.ToString();
        }

        #endregion
    }
}
