using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        [Summary("Displays information about the bot.")]
        public async Task InfoAsync()
        {
            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = "Hello world!",
                Description = "I am a description set by initializer."
            };
            // Or with methods
            embed.WithColor(Color.Blue)
                 .WithTitle("Brutel Bot Information")
                 .WithDescription(".")
                 .AddField("What i am able to for you:", "Nothing.. for now. I am just a bot being brutel.",true);

            var info = embed.Build();

            await ReplyAsync(embed: info);
        }
    }
}
