using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
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

            var storage = Unity.Resolve<IDataStorage>();

            var connection = Unity.Resolve<Connection>();

            await connection.Initialize(
                new BotConfig
                {
                    Token = storage.RestoreObject<string>("Config/BotToken")
                });

            Console.ReadKey();
        }
    }

}
