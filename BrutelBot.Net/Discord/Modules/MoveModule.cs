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
    public class MoveModule : ModuleBase<SocketCommandContext>
    {
        [Command("move")]
        [Summary("Moves all online members to the channel of the game the members are playing")]
        [RequireUserPermission(GuildPermission.MoveMembers)]
        [RequireBotPermission(GuildPermission.MoveMembers)]
        public async Task MovePlayers()
        {
            var players = Context.Guild.Users;
            var filteredPlayers = players.Where(x => x.Status != UserStatus.Offline && !x.IsBot);
            var voiceChannels = Context.Guild.VoiceChannels;

            foreach (var player in filteredPlayers)
            {
                if (player.Activity != null)
                {
                    if (player.Activity.Type == ActivityType.Playing)
                    {
                        string game = player.Activity.Name;
                        switch (game)
                        {
                            case "Anthem":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Anthem");
                                break;
                            case "Apex Legends":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Apex Legends");
                                break;
                            case "Dota 2":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Doto");
                                break;
                            case "For Honor":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Fol Honol!");
                                break;
                            case "Overwatch":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Overwatch");
                                break;
                            case "MORDHAU":
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Mordhau");
                                break;
                            default:
                                await DiscordUtilities.MoveToChannel(player, voiceChannels, "Other Games");
                                break;
                        }
                    }
                }
            }

        }
    }
}
