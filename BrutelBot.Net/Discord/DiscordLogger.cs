using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace BrutelBot.Discord
{
    public class DiscordLogger
    {
        ILogger _logger;

        public DiscordLogger(ILogger logger)
        {
            _logger = logger;
        }

        public Task Log(LogMessage logMessage)
        {
            _logger.Log(logMessage.Message);
            return Task.CompletedTask;
        }
    }
}
