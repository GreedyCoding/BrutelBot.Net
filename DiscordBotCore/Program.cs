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
        }
    }

}
