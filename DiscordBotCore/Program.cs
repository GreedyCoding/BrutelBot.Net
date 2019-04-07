using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello Discord");

            var commands = Unity.Resolve<CommandHandler>();
            
            await commands.InstallCommandsAsync();

            var connection = Unity.Resolve<Connection>();

            await connection.Initialize(
                new BotConfig
                {
                    Token = StorageHandler.GetToken() 
                });


            Console.ReadKey();
        }

    }

}
