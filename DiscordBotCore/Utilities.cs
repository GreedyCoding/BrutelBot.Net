using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    public static class Utilities
    {
        public static void ClearLastLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop -1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void WriteLineOfChars(char character)
        {
            Console.Write(new string(character, Console.WindowWidth));
        }

        public static void CheckStartArguments(string[] args)
        {
            if (args != null)
            {
                foreach (string arg in args)
                {
                    if (arg == "--reset")
                    {
                        WriteLineOfChars('!');
                        Console.WriteLine("Flag for config reset is set.\n" +
                                          "If you dont want to reset the config of the bot, please close the program,\n" +
                                          "and make sure you dont have any startarguments specified");
                        WriteLineOfChars('!');
                        ConfigHandler.SetConfig();
                    }
                }
            }
        }
    }
}
