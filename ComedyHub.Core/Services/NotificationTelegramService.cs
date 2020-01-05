using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using ComedyHub.Core.Helpers;
using System.Threading.Tasks;
using System.Net;
using ComedyHub.Core.Configuration.Contracts;
using System.Net.Http;
using ComedyHub.Model.Notification.Telegram;
using Newtonsoft.Json;

namespace ComedyHub.Core.Services
{
    public class NotificationTelegramService : INotificationTelegramService
    {
        private readonly ITelegramApiSettings _telegramApiSettings;

        public NotificationTelegramService(ITelegramApiSettings telegramApiSettings)
        {
            _telegramApiSettings = telegramApiSettings;
        }

        private string UrlTelegram => _telegramApiSettings.Url + PrivateTokens.ACCESS_TOKEN_TELEGRAM + "/sendPhoto";

        public async Task SendTelegramSucessNotification(PublishedModel memePublished)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var telegramMessage = new TelegramPhotoMessage()
                    {
                        Text = $"<a href=\"{memePublished.PublishedURL}\">{memePublished.Message}.</a>" +
                               $"\nPublished at: {memePublished.PublishedAt}." +
                               $"\nMeme from: {memePublished.MemeProvider} ",

                        ChatId = _telegramApiSettings.ReceiverId,
                        ParseMode = _telegramApiSettings.ParseMode,
                        PhotoUrl = memePublished.ImageUrl
                    };

                    var messageJson = JsonConvert.SerializeObject(telegramMessage);

                    var data = new StringContent(messageJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(UrlTelegram, data);
                }
            }
            catch
            {
                //logg
            }
        }

        public async Task SendTelegramFailureNotification(Exception exception)
        {
            throw new NotImplementedException();
        }

    }
}
