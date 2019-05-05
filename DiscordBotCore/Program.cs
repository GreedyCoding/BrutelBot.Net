﻿using BrutelBot.Discord;
using BrutelBot.Discord.Entities;
using System;
using System.Threading.Tasks;

namespace BrutelBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting up BrutelOS...");

            Utilities.CheckStartArguments(args);

            IoC.RegisterTypes();

            var commands = IoC.Resolve<CommandHandler>();
            await commands.InstallCommandsAsync();

            var connection = IoC.Resolve<Connection>();
            await connection.Initialize(ConfigHandler.config);

            await Task.Delay(-1);
        }

    }

}
