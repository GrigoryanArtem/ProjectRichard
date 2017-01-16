namespace ProjectRichard.Model.Bot
{
    internal class BotConstants
    {
        static internal char PrefixChar
        {
            get
            {
                return '-';
            }
        }

        static internal string TimeCommand
        {
            get
            {
                return "time";
            }
        }

        static internal string GetNationInfoCommand
        {
            get
            {
                return "nation";
            }
        }

        static internal string UpdateCommand
        {
            get
            {
                return "update";
            }
        }

        static internal string CreateRoomCommand
        {
            get
            {
                return "create room";
            }
        }

        static internal string NumberOfPlayers
        {
            get
            {
                return "numberOfPlayers";
            }
        }

        static internal string JoinCommand
        {
            get
            {
                return "join";
            }
        }

        static internal string BannedNation
        {
            get
            {
                return "bannedNation";
            }
        }

        static internal string CreateGameCommand
        {
            get
            {
                return "create game";
            }
        }

        static internal string GameName
        {
            get
            {
                return "gameName";
            }
        }

        static internal string Separator
        {
            get
            {
                return new string('=', 50);
            }
        }

        static internal string PropertyFormat
        {
            get
            {
                return "{0}:\n\t{1}\n";
            }
        }

        static internal string GetNationInfoParameter
        {
            get
            {
                return "name";
            }
        }

    }
}