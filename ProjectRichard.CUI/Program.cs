using System;
using ProjectRichard.Model.Bot;
using Discord;

namespace ProjectRichard.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordBot bot = new DiscordBot(Log);

            bot.BotToken = Properties.Settings.Default.BotToken;
            bot.Start();
        }

        static void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] [{e.Message}]");
        }
    }
}
