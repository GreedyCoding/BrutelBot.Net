using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    class Program
    {
        static BotConfig config;

        static async Task Main(string[] args)
        {
            Unity.RegisterTypes();
            Console.WriteLine("Starting up BrutelOS...");
            Console.WriteLine("Trying to retrieve info from BrutelStorage.");


            var commands = Unity.Resolve<CommandHandler>();
            
            await commands.InstallCommandsAsync();

            var connection = Unity.Resolve<Connection>();

            config = new BotConfig
            {
                Token = StorageHandler.GetToken(),
                Prefix = StorageHandler.GetPrefix()
            };

            await connection.Initialize(config);

            Console.ReadKey();
        }

    }

}
