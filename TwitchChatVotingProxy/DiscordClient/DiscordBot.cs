﻿using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.API;
using Discord.Interactions;
using Discord.API;
using VotingProxy;

namespace VotingProxy.VotingDiscordClient
{
    public class DiscordBot
    {
        private DiscordCredentials credentials;
        private DiscordSocketClient _client;
        private ILogger logger = Log.Logger.ForContext<DiscordBot>();

        private Dictionary<int, string> buttonIds = new Dictionary<int, string>();

        private ConnectionState connectionState;

        //Events
        public event EventHandler OnBotConnected;

        public event EventHandler OnBotDisconnected;

        public event EventHandler<BotVoteEventArgs> OnVoteReceived;

        //Methods
        private ulong ToSnowflake(string input)
        {
            int result = 0;
            try
            {
                result = Int32.Parse(input);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                
            }
            return (ulong)result;
        }

        public DiscordBot(DiscordCredentials credentials)
        {
            logger.Information("Creating new bot class");
            this.credentials = credentials;
        }

        public void SendVoteMessage(List<IVoteOption> options, EVotingMode votingMode)
        {
            logger.Information("Sending vote message");
            string title = "Time for a new effect! Vote between:";
            string optMsg = string.Empty;
            string footer = string.Empty;
            foreach (IVoteOption opt in options)
            {
                string msg = string.Empty;
                msg += $"{opt.Matches[0]} : {opt.Label}\n";
            }
            if (votingMode == EVotingMode.PERCENTAGE)
            {
                footer = "Votes will affect the chance for one of the effects to occur.";
            }

            var embed = new EmbedBuilder
            {
                Title = title,
                Description = optMsg,
            };
            if (!string.IsNullOrEmpty(footer))
            {
                embed.WithFooter(footer);
            }
           
            embed.WithAuthor(_client.CurrentUser);
            embed.WithCurrentTimestamp();
            var comps = new ComponentBuilder();
            foreach (IVoteOption opt in options)
            {
                comps.WithButton(label: $"Effect #{opt.Matches[0]}", customId: $"effect-{opt.Matches[0]}");
                buttonIds.Add(Int32.Parse(opt.Matches[0]), $"effect-{opt.Matches[0]}");
            }
            _client.GetGuild(ToSnowflake(credentials.GuildID)).GetTextChannel(ToSnowflake(credentials.ChannelId)).SendMessageAsync(embed: embed.Build(), components: comps.Build());
            logger.Information("Vote message sent!");
        }

        private Task ButtonPressed(SocketMessageComponent component)
        {
            foreach (var item in buttonIds)
            {
                if (item.Value == component.Data.CustomId)
                {
                    OnVoteReceived?.Invoke(this, new BotVoteEventArgs()
                        {
                            UserId = (int)component.User.Id,
                            Vote = item.Key
                        }
                    );
                    break;
                }
            }
            return Task.CompletedTask;
        }

        private Task Hearbeat(int a, int b)
        {
            ConnectionState nowState = _client.ConnectionState;
            if (nowState != connectionState)
            {
                connectionState = nowState;
                switch (connectionState)
                {
                    case ConnectionState.Connected:
                        OnBotConnected?.Invoke(this, EventArgs.Empty);
                        break;
                    case ConnectionState.Disconnected:
                        OnBotDisconnected?.Invoke(this, EventArgs.Empty);
                        break;
                }

            }

            return Task.CompletedTask;
        }

        public void StartBot()
        {
            logger.Information("Starting bot!");
            _client = new DiscordSocketClient();

            _client.LoginAsync(TokenType.Bot, credentials.OAuth);
            _client.StartAsync();
            _client.SetGameAsync("For Votes!", type: ActivityType.Listening);

            _client.LatencyUpdated += Hearbeat;
            _client.ButtonExecuted += ButtonPressed;
        }

        public void StopBot()
        {
            logger.Information("Stopping bot!");
            _client.LogoutAsync();
            _client.StopAsync();
        }
    }

    public class BotVoteEventArgs
    {
        public int Vote;
        public int UserId;
    }

}
