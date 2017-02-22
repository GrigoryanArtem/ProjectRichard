namespace ProjectRichard.Model.Bot.BotCommands
{
    internal class CommandsConstants
    {
        public const string TimeCommandName = "time";
        public const string TimeCommandDescription = "Печатает текущую дату и время.";

        public const string RollCommandName = "roll";
        public const string RollCommandDescription = "Генерирует случайное число от 1 до 100 включительно. Полезно при решении спорных ситуаций.";

        public const string CreateRoomCommandName = "create room";
        public const string CreateRoomCommandDescription = "Создает комнату для n игроков.";
        public const string CreateRoomCommandParameterName = "number of players";

        public const string RoomInfoCommandName = "room info";
        public const string RoomInfoCommandDescription = "Выводит информацию о текущей игровой комнате.";

        public const string JoinCommandName = "join";
        public const string JoinCommandDescription = "Команда для входа в текущую комнату.";

        public const string ExitCommandName = "exit";
        public const string ExitCommandDescription = "Команда для выхода из текущей комнаты";

        public const string CreateGameCommandName = "create game";
        public const string CreateGameCommandDescription = "Создает игру при из сформированной комнаты.";
        public const string CreateGameCommandParameterName = "game name";

        public const string BanCommandName = "ban";
        public const string BanCommandDescription = "Создает игру при из сформированной комнаты.";
        public const string BanCommandParameterName = "nation name";

        public const string NationCommandName = "info";
        public const string NationCommandDescription = "Информация о нации.";
        public const string NationCommandParameterName = "nation name";

        public const string NationsCommandName = "nations";
        public const string NationsCommandDescription = "Список всех наций с их оценками.";

        public const string ClearCommandName = "clear";
        public const string ClearCommandDescription = "Очищает сообщение пользователя.";
        public const string ClearCommandParameterName = "user name";
    }
}
