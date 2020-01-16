using ComedyHub.Core.Auth;
using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Components;
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Services;
using ComedyHub.Core.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyHub.Host.Configuration
{
    public static class StartupConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<INineGagFetchService, NineGagFetchService>();
            services.AddSingleton<INineGagFilterService, NineGagFilterService>();
            services.AddSingleton<INineGagMapperService, NineGagMapperService>();
            services.AddSingleton<IPublishTwitterService, PublishTwitterService>();
            services.AddSingleton<INotificationTelegramService, NotificationTelegramService>();
            services.AddSingleton<IFilterService, FilterService>();
            services.AddSingleton<IRedditFetchService, RedditFetchService>();
            services.AddSingleton<IRedditFilterService, RedditFilterService>();
            services.AddSingleton<IRedditMapperService, RedditMapperService>();
            services.AddSingleton<IMapperService, MapperService>();

            return services;
        }

        public static IServiceCollection RegisterComponents(this IServiceCollection services)
        {
            services.AddSingleton<IMemeProcessor, MemeProcessor>();
            services.AddSingleton<IMemeOrchestrator, MemeOrchestrator>();
            services.AddSingleton<INineGagComponent, NineGagComponent>();
            services.AddSingleton<INotificationComponent, NotificationComponent>();
            services.AddSingleton<IPublishComponent, PublishComponent>();
            services.AddSingleton<IRedditComponent, RedditComponent>();

            return services;
        }

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramGateway, TelegramGateway>();
            services.AddSingleton<IRedditGateway, RedditGateway>();
            services.AddSingleton<INineGagGateway, NineGagGateway>();

            return services;
        }

        public static IServiceCollection RegisterAuth(this IServiceCollection services)
        {
            services.AddSingleton<IRedditAuth, RedditAuth>();
            services.AddSingleton<ITwitterAuth, TwitterAuth>();

            return services;
        }

        public static IServiceCollection RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));
            services.AddSingleton<IApplicationSettings>(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);

            services.Configure<NineGagApiSettings>(configuration.GetSection(nameof(NineGagApiSettings)));
            services.AddSingleton<INineGagApiSettings>(sp => sp.GetRequiredService<IOptions<NineGagApiSettings>>().Value);

            services.Configure<TelegramApiSettings>(configuration.GetSection(nameof(TelegramApiSettings)));
            services.AddSingleton<ITelegramApiSettings>(sp => sp.GetRequiredService<IOptions<TelegramApiSettings>>().Value);

            services.Configure<TwitterBotSettings>(configuration.GetSection(nameof(TwitterBotSettings)));
            services.AddSingleton<ITwitterBotSettings>(sp => sp.GetRequiredService<IOptions<TwitterBotSettings>>().Value);

            services.Configure<RedditApiSettings>(configuration.GetSection(nameof(RedditApiSettings)));
            services.AddSingleton<IRedditApiSettings>(sp => sp.GetRequiredService<IOptions<RedditApiSettings>>().Value);

            return services;
        }
    }
}
