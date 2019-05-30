using BrutelBot.Music;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrutelBot.Discord.Modules
{
    public class MusicModule : ModuleBase<SocketCommandContext>
    {
        MusicService musicPlayer;

        public MusicModule()
        {
            this.musicPlayer = BrutelBot.Program.musicPlayer;
        }

        [Command("Join")]
        public async Task Join()
        {
            var user = Context.User as SocketGuildUser;
            if (user.VoiceChannel is null)
            {
                await ReplyAsync("You need to connect to a voice channel.");
                return;
            }
            else
            {
                await musicPlayer.ConnectAsync(user.VoiceChannel, Context.Channel as ITextChannel);
                await ReplyAsync($"now connected to {user.VoiceChannel.Name}");
            }
        }

        [Command("Leave")]
        public async Task Leave()
        {
            var user = Context.User as SocketGuildUser;
            if (user.VoiceChannel is null)
            {
                await ReplyAsync("Please join the channel the bot is in to make it leave.");
            }
            else
            {
                await musicPlayer.LeaveAsync(user.VoiceChannel);
                await ReplyAsync($"Bot has now left {user.VoiceChannel.Name}");
            }
        }

        [Command("Play")]
        public async Task Play([Remainder]string query)
        {
            var result = await musicPlayer.PlayAsync(query, Context.Guild.Id);
            await ReplyAsync(result);
        }

        [Command("Stop")]
        public async Task Stop()
        {
            await musicPlayer.StopAsync();
            await ReplyAsync("Music Playback Stopped.");
        }

        [Command("Skip")]
        public async Task Skip()
        {
            var result = await musicPlayer.SkipAsync();
            await ReplyAsync(result);
        }

        [Command("Volume")]
        public async Task Volume(int vol)
            => await ReplyAsync(await musicPlayer.SetVolumeAsync(vol));

        [Command("Pause")]
        public async Task Pause()
            => await ReplyAsync(await musicPlayer.PauseOrResumeAsync());

        [Command("Resume")]
        public async Task Resume()
            => await ReplyAsync(await musicPlayer.ResumeAsync());

    }
}
