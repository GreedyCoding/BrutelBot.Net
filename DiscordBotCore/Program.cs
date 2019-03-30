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

            var discordBotConfig = new BotConfig
            {
                Token = "ABC",
                SocketConfig = SocketConfig.GetDefault()
            };

            await Task.Delay(-1);
        }
    }

}
