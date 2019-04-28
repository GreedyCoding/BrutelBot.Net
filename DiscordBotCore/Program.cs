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
            IoC.RegisterTypes();
            Console.WriteLine("Starting up BrutelOS...");
            Console.WriteLine("Trying to retrieve info from BrutelStorage.");


            var commands = IoC.Resolve<CommandHandler>();
            
            await commands.InstallCommandsAsync();

            var connection = IoC.Resolve<Connection>();

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
