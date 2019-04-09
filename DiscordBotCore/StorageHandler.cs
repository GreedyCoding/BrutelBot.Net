using DiscordBotCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    public class StorageHandler
    {
        static IDataStorage storage = Unity.Resolve<IDataStorage>();

        public static string GetToken()
        {
            if (FileExists("Config/BotToken.json"))
            {
                return storage.RestoreObject<string>("Config/BotToken");
            }
            else
            {
                Console.WriteLine("No Settings found. Reinitializing BrutelStorage!");
                Console.WriteLine("Please Enter your Bot Token:");
                string token = Console.ReadLine();
                SetToken(token);
                return token;
            }
        }

        public static void SetToken(string token)
        {
            storage.StoreObject(token, "Config/BotToken");
        }

        public static char GetPrefix()
        {
            if (FileExists("Config/Prefix.json"))
            {
                return storage.RestoreObject<char>("Config/Prefix");
            }
            else
            {
                Console.WriteLine("Set a prefix for your commands. Using a special character is recommended.");
                char prefix = Console.ReadKey().KeyChar;
                Console.WriteLine();
                SetPrefix(prefix);
                Console.WriteLine("BrutelStorage reinitialized. Bot is starting now");
                return prefix;

            }
        }

        public static void SetPrefix(char prefix)
        {
            storage.StoreObject(prefix, "Config/Prefix");
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
