using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    [Name("Moderator")]
    [RequireContext(ContextType.Guild)]
    public class ModeratorModule : ModuleBase<SocketCommandContext>
    {
        [Command("mute")]
        [Summary("Mutes a user")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task MuteAsync(SocketGuildUser user, int minutes, [Remainder]string reason = "No reason provided")
        {
            throw new NotImplementedException();
        }

        [Command("kick")]
        [Summary("Kicks a user")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task KickAsync(SocketGuildUser user, [Remainder]string reason = "No reason provided")
        {
            await ReplyAsync($"cya {user.Mention} :wave:");
            await user.KickAsync(reason);
        }

        [Command("ban")]
        [Summary("Bans a user")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanAsync(SocketGuildUser user, int days = 1, [Remainder]string reason = "No reason provided")
        {
            await ReplyAsync($"cya in {days} days {user.Mention} :wave:");
            await user.BanAsync(days, reason);
        }
    }
}
