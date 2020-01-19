// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-04-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-15-2020
// ***********************************************************************
// <copyright file="NotificationTelegramService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Handles the notification throught telegram</summary>
// ***********************************************************************
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Text;
using ComedyHub.Core;
using System.Threading.Tasks;
using ComedyHub.Core.Configuration.Contracts;
using System.Net.Http;
using ComedyHub.Model.Notification.TelegramMessage;
using Newtonsoft.Json;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using Microsoft.Extensions.Logging;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class NotificationTelegramService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.INotificationTelegramService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.INotificationTelegramService" />
    public class NotificationTelegramService : INotificationTelegramService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<NotificationTelegramService> _logger;
        /// <summary>
        /// The telegram gateway
        /// </summary>
        private readonly ITelegramGateway _telegramGateway;
        /// <summary>
        /// The telegram API settings
        /// </summary>
        private readonly ITelegramApiSettings _telegramApiSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationTelegramService"/> class.
        /// </summary>
        /// <param name="telegramGateway">The telegram gateway.</param>
        /// <param name="telegramApiSettings">The telegram API settings.</param>
        /// <param name="logger">The logger.</param>
        public NotificationTelegramService(ITelegramGateway telegramGateway,
                                           ITelegramApiSettings telegramApiSettings,
                                           ILogger<NotificationTelegramService> logger)
        {
            _telegramGateway = telegramGateway;
            _telegramApiSettings = telegramApiSettings;
            _logger = logger;
        }

        /// <summary>
        /// Sends the telegram sucess notification.
        /// </summary>
        /// <param name="memePublished">The meme published.</param>
        public async Task SendTelegramSucessNotification(PublishedModel memePublished)
        {
            var telegramMessage = new TelegramPhotoMessage()
            {
                Caption = $"<a href=\"{memePublished.PublishedURL}\">{memePublished.Message}.</a>\n" +
                       $"<b>Published To:</b> {memePublished.PublishedAt}.\n" +
                       $"<b>Meme from:</b> {memePublished.MemeProvider} ",
                ChatId = Auth.ReceiverInfo.TELEGRAM_MESSAGE_RECEIVER_ID,
                ParseMode = _telegramApiSettings.ParseMode,
                PhotoUrl = memePublished.ImageUrl
            };

            try
            {
                await _telegramGateway.SendPhotoMessage(telegramMessage);

                _logger.LogInformation("Sucessfully sent success notification");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to send success notification");
            }
        }

        /// <summary>
        /// Sends the telegram failure notification.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public async Task SendTelegramFailureNotification(Exception exception)
        {
            var telegramMessage = new TelegramTextMessage()
            {
                Text = $"<b>Failed to publish meme.</b>\n" +
                       $"<b>Message:</b> {exception.Message}.\n" +
                       $"<b>Stack Trace:</b> <pre> {exception.StackTrace} </pre>",
                ChatId = Auth.ReceiverInfo.TELEGRAM_MESSAGE_RECEIVER_ID,
                ParseMode = _telegramApiSettings.ParseMode
            };

            try
            {
                await _telegramGateway.SendTextMessage(telegramMessage);
                _logger.LogInformation("Sucessfully sent failure notification");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send failure notification");
            }
        }

    }
}
