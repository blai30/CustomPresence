using CustomPresence.Options;
using CustomPresence.Services;
using Discord;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CustomPresence
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<DiscordOptions>(Configuration.GetSection("Discord"))

                // Add discord game sdk.
                .AddSingleton(provider =>
                {
                    var options = provider.GetRequiredService<IOptions<DiscordOptions>>().Value;
                    var discord = new Discord.Discord(options.ClientId, (ulong) CreateFlags.Default);
                    return discord;
                })

                .AddHostedService<DiscordService>()
                .AddHostedService<ActivityService>()
                ;
        }
    }
}
