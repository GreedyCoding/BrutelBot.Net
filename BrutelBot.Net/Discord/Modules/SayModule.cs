using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrutelBot.Discord.Modules
{
    public class SayModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
	    [Summary("Echoes a message.")]
	    public async Task SayAsync([Remainder]string echo)
        {
            if (echo.ToLower() == "gaymo" || echo.ToLower() == "gaym0")
            {
                await ReplyAsync("Suck it!");
            }
            else
            {
                await ReplyAsync(echo);
            }
        }
    }
}
