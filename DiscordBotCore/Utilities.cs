using DiscordBotCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    public class Utilities
    {
        static IDataStorage storage = Unity.Resolve<IDataStorage>();

        public static string GetToken()
        {
            return storage.RestoreObject<string>("Config/BotToken");
        }

        public static void SetToken(string token)
        {
            storage.StoreObject(token, "Config/BotToken");
        }

        public static int ReturnInt(int i)
        {
            return i;
        }
    }
}
