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

            var connection = Unity.Resolve<Connection>();
            var commands = Unity.Resolve<CommandHandler>();
            
            await commands.InstallCommandsAsync();

            await connection.SetInfo("Mapex");
            await connection.Initialize(
                new BotConfig
                {
                    Token = Utilities.GetToken()
                });


            Console.ReadKey();
        }

    }

}
