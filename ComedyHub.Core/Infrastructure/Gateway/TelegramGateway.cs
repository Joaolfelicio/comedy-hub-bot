using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Model.Notification.TelegramMessage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    public class TelegramGateway : ITelegramGateway
    {
        private readonly ITelegramApiSettings _telegramApiSettings;

        public TelegramGateway(ITelegramApiSettings telegramApiSettings)
        {
            _telegramApiSettings = telegramApiSettings;
        }

        public async Task SendTextMessage(TelegramTextMessage telegramTextMessage)
        {
            string UrlTelegramPhotoMessage = _telegramApiSettings.Url + Auth.AccessToken.ACCESS_TOKEN_TELEGRAM + "/sendMessage";

            var data = ConvertToJsonData(telegramTextMessage);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(UrlTelegramPhotoMessage, data);
            }
        }

        public async Task SendPhotoMessage(TelegramPhotoMessage telegramPhotoMessage)
        {
            string UrlTelegramPhotoMessage = _telegramApiSettings.Url + Auth.AccessToken.ACCESS_TOKEN_TELEGRAM + "/sendPhoto";

            var data = ConvertToJsonData(telegramPhotoMessage);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(UrlTelegramPhotoMessage, data);
            }
        }

        private StringContent ConvertToJsonData(TelegramMessage telegramMessage)
        {
            var messageJson = JsonConvert.SerializeObject(telegramMessage);

            var data = new StringContent(messageJson, Encoding.UTF8, "application/json");

            return data;
        }
    }
}
