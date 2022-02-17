using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
//This class prepares the bot to handle command by making sure the bot is read every message posted on the discord server and waiting for the specific key to be typed
namespace Discord_bot.Services
{
    public class CommandHandler
    {
        public static IServiceProvider _provider;
        public static DiscordSocketClient _client;
        public static CommandService _command;
        public static IConfigurationRoot _config;
        public CommandHandler(DiscordSocketClient client, CommandService command, IConfigurationRoot config, IServiceProvider provider)
        {
            _provider = provider;
            _client = client;
            _command = command;
            _config = config;

            _client.Ready += OnReady;
            _client.MessageReceived += MessagesReceived;
        }

        private async Task MessagesReceived(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message.Author.IsBot)
                return;
            var context = new SocketCommandContext(_client, message);

            int pos = 0;
            if (message.HasStringPrefix(_config["prefix"], ref pos)) 
            {
                var result = await _command.ExecuteAsync(context, pos, _provider);

                if (!result.IsSuccess)
                {
                    var reason = result.Error;
                    await context.Channel.SendMessageAsync($"Error: \n{reason}");
                    Console.WriteLine(reason);
                }
            }
        }

        private Task OnReady()
        {

            Console.WriteLine($"Connected as {_client.CurrentUser.Username}#{_client.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}
