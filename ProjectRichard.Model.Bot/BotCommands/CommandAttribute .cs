﻿using Discord.Commands;
using ProjectRichard.Data;
using System;

namespace ProjectRichard.Model.Bot.BotCommands
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public BotRoles Role { get; set; } = BotRoles.User;

        public string ParameterName { get; set; }

        public ParameterType ParameterType { get; set; } = ParameterType.Required;
    }
}
