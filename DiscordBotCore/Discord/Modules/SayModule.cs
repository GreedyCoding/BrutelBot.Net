using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    public class SayModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
	    [Summary("Echoes a message.")]
	    public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
        {
            if (echo.ToLower() == "gaymo" || echo.ToLower() == "gaym0")
            {
                ReplyAsync("Suck it!");
            }
            else
            {
                ReplyAsync(echo);
            }
            return Task.CompletedTask;
        }
    }
}
