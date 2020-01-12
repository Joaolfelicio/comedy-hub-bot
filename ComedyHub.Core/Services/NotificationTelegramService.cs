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
using NLog;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;

namespace ComedyHub.Core.Services
{
    public class NotificationTelegramService : INotificationTelegramService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ITelegramGateway _telegramGateway;
        private readonly ITelegramApiSettings _telegramApiSettings;

        public NotificationTelegramService(ITelegramGateway telegramGateway,
                                           ITelegramApiSettings telegramApiSettings)
        {
            _telegramGateway = telegramGateway;
            _telegramApiSettings = telegramApiSettings;
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
            }
            catch (Exception exception)
            {
                logger.Error(exception);
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
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

    }
}
