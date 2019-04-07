using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    public class DeleteModule : ModuleBase<SocketCommandContext>
    {
        [Command("delete")]
        [Summary("Deletes messages from a channel. Ammount can be specified as argument. Defaults to 10")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task DeleteMessageAsync(int amount = 10)
        {
            throw new NotImplementedException();
        }
    }
}
