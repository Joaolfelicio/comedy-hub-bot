using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Text;
using ComedyHub.Core.Helpers;
using System.Threading.Tasks;
using ComedyHub.Core.Configuration.Contracts;
using System.Net.Http;
using ComedyHub.Model.Notification.TelegramMessage;
using Newtonsoft.Json;
using NLog;

namespace ComedyHub.Core.Services
{
    public class NotificationTelegramService : INotificationTelegramService
    {
        private readonly ITelegramApiSettings _telegramApiSettings;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public NotificationTelegramService(ITelegramApiSettings telegramApiSettings)
        {
            _telegramApiSettings = telegramApiSettings;
        }

        public async Task SendTelegramSucessNotification(PublishedModel memePublished)
        {
            string UrlTelegramOnSuccess = _telegramApiSettings.Url + PrivateTokens.ACCESS_TOKEN_TELEGRAM + "/sendPhoto";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var telegramMessage = new TelegramPhotoMessage()
                    {
                        Caption = $"<a href=\"{memePublished.PublishedURL}\">{memePublished.Message}.</a>\n" +
                               $"<b>Published at:</b> {memePublished.PublishedAt}.\n" +
                               $"<b>Meme from:</b> {memePublished.MemeProvider} ",

                        ChatId = PrivateTokens.TELEGRAM_MESSAGE_RECEIVER_ID,
                        ParseMode = _telegramApiSettings.ParseMode,
                        PhotoUrl = memePublished.ImageUrl
                    };

                    var messageJson = JsonConvert.SerializeObject(telegramMessage);

                    var data = new StringContent(messageJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(UrlTelegramOnSuccess, data);
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        public async Task SendTelegramFailureNotification(Exception exception)
        {
            string UrlTelegramOnFailure = _telegramApiSettings.Url + PrivateTokens.ACCESS_TOKEN_TELEGRAM + "/sendMessage";
            
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var telegramMessage = new TelegramTextMessage()
                    {
                        Text = $"<b>Failed to publish meme.</b>\n" +
                               $"<b>Message:</b> {exception.Message}.\n" +
                               $"<b>Stack Trace:</b> <pre> {exception.StackTrace} </pre>",

                        ChatId = PrivateTokens.TELEGRAM_MESSAGE_RECEIVER_ID,
                        ParseMode = _telegramApiSettings.ParseMode
                    };

                    var messageJson = JsonConvert.SerializeObject(telegramMessage);

                    var data = new StringContent(messageJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(UrlTelegramOnFailure, data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

    }
}
