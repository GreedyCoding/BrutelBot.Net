﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
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
        [Summary("Deletes messages from a channel. Ammount can be specified as argument. Defaults to 10, Maximum is 100")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task DeleteMessageAsync(int amount = 10)
        {
            if (amount <= 0)
            {
                await ReplyAsync("The amount of messages to remove must be positive.");
                return;
            }

            if (amount <= 100)
            {
                var messages = await Context.Channel.GetMessagesAsync(Context.Message, Direction.Before, amount).FlattenAsync();
                var filteredMessages = messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14);

                var count = filteredMessages.Count();

                if (count == 0)
                {
                    await ReplyAsync("Nothing to delete.");
                }
                else
                {
                    await (Context.Channel as ITextChannel).DeleteMessagesAsync(filteredMessages);
                    await ReplyAsync($"Done. Removed {count} {(count > 1 ? "messages" : "message")}.");
                }
            }
        }
    }
}
