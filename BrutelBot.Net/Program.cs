using BrutelBot.Discord;
using BrutelBot.Discord.Entities;
using BrutelBot.Music;
using System;
using System.Threading.Tasks;
using Victoria;

namespace BrutelBot
{
    class Program
    {
        public static MusicService musicPlayer = IoC.Resolve<MusicService>();

        static async Task Main(string[] args)
        {

            IoC.RegisterTypes();

            Console.WriteLine("Starting up BrutelOS...");

            await musicPlayer.InitializeAsync();

            Utilities.CheckStartArguments(args);

            var commands = IoC.Resolve<CommandHandler>();
            await commands.InstallCommandsAsync();

            var connection = IoC.Resolve<Connection>();
            await connection.InitializeAsync(ConfigHandler.config);

            var lavaClient = IoC.Resolve<LavaSocketClient>();
            await lavaClient.StartAsync(connection._client);

            await Task.Delay(-1);
        }

    }

}
