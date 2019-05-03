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
            Console.WriteLine("Starting up BrutelOS...");

            if (args != null)
            {
                foreach (string arg in args)
                {
                    if(arg == "--reset")
                    {
                        Utilities.WriteDashLine();
                        Console.WriteLine("Flag for config reset is set.\n" +
                                          "If you dont want to reset the config of the bot, please close the program,\n" +
                                          "and make sure you dont have any startarguments specified");
                        Utilities.WriteDashLine();
                        ConfigHandler.SetConfig();
                    }
                }
            }


            IoC.RegisterTypes();

            var commands = IoC.Resolve<CommandHandler>();
            await commands.InstallCommandsAsync();

            var connection = IoC.Resolve<Connection>();
            await connection.Initialize(ConfigHandler.config);

            await Task.Delay(-1);
        }

    }

}
