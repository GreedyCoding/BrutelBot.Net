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
        static IDataStorage storage = IoC.Resolve<IDataStorage>();

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static void SaveObject(object obj, string path)
        {
            storage.StoreObject(obj, path);
        }

        public static string GetToken()
        {
            if (FileExists("Config/BotToken.json"))
            {
                Console.WriteLine("Bot token found.");
                return storage.RestoreObject<string>("Config/BotToken");
            }
            else
            {
                Console.WriteLine("No Settings found. Reinitializing BrutelStorage!");
                Console.WriteLine("Please Enter your Bot Token:");
                string token = Console.ReadLine();
                SaveObject(token, "Config/BotToken");
                return token;
            }
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
                SaveObject(prefix, "Config/Prefix");
                Console.WriteLine("BrutelStorage reinitialized. Bot is starting now");
                return prefix;

            }
        }

        public static string GetSetting(int index)
        {
            string[] str = storage.RestoreObject<string[]>("Config/Test");
            return str[index];
        }
    }
}
