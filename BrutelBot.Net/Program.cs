using BrutelBot.Discord;
using BrutelBot.Discord.Entities;
using BrutelBot.Music;
using System;
using System.Threading.Tasks;

namespace BrutelBot
{
    class Program
    {
        public static MusicService musicPlayer = IoC.Resolve<MusicService>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting up BrutelOS...");

            await musicPlayer.InitializeAsync();

            Utilities.CheckStartArguments(args);

            IoC.RegisterTypes();

            var commands = IoC.Resolve<CommandHandler>();
            await commands.InstallCommandsAsync();

            var connection = IoC.Resolve<Connection>();
            await connection.InitializeAsync(ConfigHandler.config);

            await Task.Delay(-1);
        }

    }

}
