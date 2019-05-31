using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrutelBot.Discord.Logging
{
    public interface ILogger
    {
        void Log(string message);

        Task Log(LogMessage message);
    }
}
