using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using BrutelBot.Discord.Entities;
using BrutelBot.Discord.Logging;

namespace BrutelBot.Discord
{
    public class Connection
    {
        private readonly DiscordSocketClient _client;

        private readonly ILogger _logger;

        public Connection(ILogger logger, DiscordSocketClient client)
        {
            _logger = logger;
            _client = client;
        }


        internal async Task InitializeAsync(BotConfig config)
        {
            _client.Log += _logger.Log;

            await _client.LoginAsync(TokenType.Bot, config.Token);
            await _client.SetGameAsync(config.BotGame);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
