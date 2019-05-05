using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrutelBot.Discord.Modules
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
                 .AddField("Delete", "!delete {amount}* {pinned}* - Deletes messages from a channel.\n" +
                                     "*Arguments are optional - amount defaults to 10, pinned to false\n")
                 .AddField("Flash", "!flash - Lets the BotStatus LED flash for 10 seconds")
                 .AddField("Help", "!help - Shows bot information with all available commands")
                 .AddField("Moderation", "!ban {user} {days}* {reason}* - Bans a User for specified amount of days\n" +
                                         "!kick {user} {reason}* - Kicks a User\n" +
                                         "!mute {user} {minutes}* {reason}* - Mutes a user for specified amount of minutes\n" +
                                         "* Arguments are optional - days defaults to 1, minutes defaults to 15")
                 .AddField("Move", "!move - Moves all users into the channel of the game they are playing at the moment.")
                 .WithFooter(footer => footer.Text = "©BrutelBot")
                 .WithCurrentTimestamp();

            var info = embed.Build();

            await ReplyAsync(embed: info);
        }
    }
}
