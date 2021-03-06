﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrutelBot.Discord.Modules
{
    public class FlashingModule : ModuleBase<SocketCommandContext>
    {
        [Command("flash")]
        [Summary("Sets the bot userstatus to flashing between status")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.Administrator)]
        public async Task StartBlinking()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(10))
            {
                await Context.Client.SetStatusAsync(UserStatus.Online);
                await Task.Delay(500);
                await Context.Client.SetStatusAsync(UserStatus.Idle);
                await Task.Delay(500);
                await Context.Client.SetStatusAsync(UserStatus.DoNotDisturb);
                await Task.Delay(500);
            }
            s.Stop();
            await Context.Client.SetStatusAsync(UserStatus.Online);
        }
    }
}
