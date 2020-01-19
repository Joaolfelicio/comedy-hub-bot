// ***********************************************************************
// Assembly         : ComedyHub.Host
// Author           : Joaolfelicio
// Created          : 01-16-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="StartupConfiguration.cs" company="ComedyHub.Host">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class StartupConfiguration.
    /// </summary>
    public static class StartupConfiguration
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<INineGagFetchService, NineGagFetchService>();
            services.AddSingleton<INineGagMapperService, NineGagMapperService>();
            services.AddSingleton<IPublishTwitterService, PublishTwitterService>();
            services.AddSingleton<INotificationTelegramService, NotificationTelegramService>();
            services.AddSingleton<IFilterService, FilterService>();
            services.AddSingleton<IRedditFetchService, RedditFetchService>();
            services.AddSingleton<IRedditMapperService, RedditMapperService>();
            services.AddSingleton<IMapperService, MapperService>();

            return services;
        }

        /// <summary>
        /// Registers the components.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
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

        /// <summary>
        /// Registers the infrastructure.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramGateway, TelegramGateway>();
            services.AddSingleton<IRedditGateway, RedditGateway>();
            services.AddSingleton<INineGagGateway, NineGagGateway>();
            services.AddSingleton<IContentGateway, ContentGateway>();

            return services;
        }

        /// <summary>
        /// Registers the authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection RegisterAuth(this IServiceCollection services)
        {
            services.AddSingleton<IRedditAuth, RedditAuth>();
            services.AddSingleton<ITwitterAuth, TwitterAuth>();

            return services;
        }

        /// <summary>
        /// Registers the configurations.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IServiceCollection.</returns>
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
