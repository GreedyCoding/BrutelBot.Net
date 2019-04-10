using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        [Summary("Displays information about the bot.")]
        public async Task HelpAsync()
        {
            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = "Help Window",
                Description = "Displays all commands"
            };
            // Or with methods
            embed.WithColor(Color.Blue)
                 .WithTitle("Bot Help")
                 .WithDescription("Below is a list with all currently available commands for BrutelBot")
                 .AddField("Help", "!help - Shows bot information with all available commands")
                 .AddField("Moderation", "!ban {user} {days}* {reason}* - Bans a User for specified amount of days\n" +
                                         "!kick {user} {reason}* - Kicks a User\n" +
                                         "!mute {user} {minutes}* {reason}* - Mutes a user for specified amount of minutes\n" +
                                         "* Arguments are optional - days defaults to 1, minutes defaults to 15")
                 .AddField("Delete", "!delete {amount}* {pinned}* - Deletes messages from a channel.\n" +
                                     "*Arguments are optional - amount defaults to 10, pinned to false\n")
                 .WithFooter(footer => footer.Text = "©BrutelBot")
                 .WithCurrentTimestamp();

            var info = embed.Build();

            await ReplyAsync(embed: info);
        }
    }
}
