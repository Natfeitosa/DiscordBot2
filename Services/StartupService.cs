using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Discord_bot.Services
{//This class starts up the bot and logs in to Discord
    public class StartupService
    {
        public static IServiceProvider _provider;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _command;
        private readonly IConfigurationRoot _config;

        public StartupService(IServiceProvider provider, DiscordSocketClient client, CommandService command, IConfigurationRoot config)
        {
            _provider = provider;
            _client = client;
            _command = command;
            _config = config;
        }

        public async Task StartAsync()
        {
            string token = _config["tokens:discord"];//Searches for the bot API token in the config files
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Unable to read token of the bot");
                return;
            }
            await _client.LoginAsync(Discord.TokenType.Bot, token);//Logs the Bot into the discord server
            await _client.StartAsync();

            await _command.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), _provider);
            
        }
       
    }
}
