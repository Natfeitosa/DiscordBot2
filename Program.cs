using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Rest;
using Discord.Net;
using Discord.Commands;
using Discord.Addons.Interactive;
using NetEscapades.Configuration.Yaml;


namespace Discord_bot
{

    class Program
    {
        public static async Task Main(string[] args)
            => await Startup.RunAsync(args);
             
    }
}
