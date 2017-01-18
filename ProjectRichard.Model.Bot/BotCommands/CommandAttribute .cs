using System;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
