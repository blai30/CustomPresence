using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomPresence.Services
{
    public class DiscordService : BackgroundService
    {
        private readonly ILogger<DiscordService> _logger;
        private readonly Discord.Discord _discord;

        public DiscordService(
            ILogger<DiscordService> logger,
            Discord.Discord discord)
        {
            _logger = logger;
            _discord = discord;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _discord.RunCallbacks();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
