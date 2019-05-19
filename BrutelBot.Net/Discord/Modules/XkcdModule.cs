using BrutelBot.API;
using BrutelBot.API.Xkcd;
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
    public class XkcdModule : ModuleBase<SocketCommandContext>
    {
        [Command("xkcd")]
        public async Task GetComic(int comicNumber = 0)
        {
            ComicModel comic = await ComicHandler.LoadComic(comicNumber);
            await ReplyAsync(comic.Img);
        }
    }
}
