using System;

namespace ProjectRichard.Model.Bot
{
    public class BotException : Exception
    {
        public BotException(string message) : base(message) { } 
    }
}
