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
    public class NotificationTelegramService : INotificationTelegramService
    {
        private readonly ILogger<NotificationTelegramService> _logger;
        private readonly ITelegramGateway _telegramGateway;
        private readonly ITelegramApiSettings _telegramApiSettings;

        public NotificationTelegramService(ITelegramGateway telegramGateway,
                                           ITelegramApiSettings telegramApiSettings,
                                           ILogger<NotificationTelegramService> logger)
        {
            _telegramGateway = telegramGateway;
            _telegramApiSettings = telegramApiSettings;
            _logger = logger;
        }

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
