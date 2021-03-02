using System;
using System.Threading;
using System.Threading.Tasks;
using CustomPresence.Options;
using Discord;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomPresence.Services
{
    public class ActivityService : IHostedService
    {
        private readonly ILogger<ActivityService> _logger;
        private readonly IOptions<DiscordOptions> _options;
        private readonly Discord.Discord _discord;

        private ActivityManager _activityManager;
        private long _startTime;

        public ActivityService(
            ILogger<ActivityService> logger,
            IOptions<DiscordOptions> options,
            Discord.Discord discord)
        {
            _logger = logger;
            _options = options;
            _discord = discord;

            _startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _activityManager = _discord.GetActivityManager();
            var options = _options.Value;

            var activity = new Activity
            {
                Details = options.Details ?? string.Empty,
                State = options.State ?? string.Empty,
                Party =
                {
                    Id = options.PartyId ?? string.Empty,
                    Size = {
                        CurrentSize = options.PartySize ?? default,
                        MaxSize = options.PartyMax ?? default
                    }
                },
                Timestamps =
                {
                    Start = options.StartTimestamp ?? _startTime,
                    End = options.EndTimestamp ?? default
                },
                Assets =
                {
                    LargeImage = options.LargeImageKey ?? string.Empty,
                    LargeText = options.LargeImageText ?? string.Empty,
                    SmallImage = options.SmallImageKey ?? string.Empty,
                    SmallText = options.SmallImageText ?? string.Empty
                },
                Instance = options.Instance ?? default
            };

            _activityManager.UpdateActivity(activity, result =>
            {
                if (result != Result.Ok)
                {
                    _logger.LogError($"{GetType().Name} failed unexpectedly");
                }
            });

            _logger.LogInformation($"{GetType().Name} started");
            await Task.CompletedTask;
            _logger.LogInformation($"Activity state set: {activity.State}");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{GetType().Name} stopped");
            await Task.CompletedTask;
        }
    }
}
