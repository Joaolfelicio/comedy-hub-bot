// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="TelegramGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class TelegramGateway.
    /// Implements the <see cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.ITelegramGateway" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.ITelegramGateway" />
    public class TelegramGateway : ITelegramGateway
    {
        /// <summary>
        /// The telegram API settings
        /// </summary>
        private readonly ITelegramApiSettings _telegramApiSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramGateway"/> class.
        /// </summary>
        /// <param name="telegramApiSettings">The telegram API settings.</param>
        public TelegramGateway(ITelegramApiSettings telegramApiSettings)
        {
            _telegramApiSettings = telegramApiSettings;
        }

        /// <summary>
        /// Sends the text message.
        /// </summary>
        /// <param name="telegramTextMessage">The telegram text message.</param>
        public async Task SendTextMessage(TelegramTextMessage telegramTextMessage)
        {
            string UrlTelegramPhotoMessage = _telegramApiSettings.Url + Auth.AccessToken.ACCESS_TOKEN_TELEGRAM + "/sendMessage";

            var data = ConvertToJsonData(telegramTextMessage);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(UrlTelegramPhotoMessage, data);
            }
        }

        /// <summary>
        /// Sends the photo message.
        /// </summary>
        /// <param name="telegramPhotoMessage">The telegram photo message.</param>
        public async Task SendPhotoMessage(TelegramPhotoMessage telegramPhotoMessage)
        {
            string UrlTelegramPhotoMessage = _telegramApiSettings.Url + Auth.AccessToken.ACCESS_TOKEN_TELEGRAM + "/sendPhoto";

            var data = ConvertToJsonData(telegramPhotoMessage);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(UrlTelegramPhotoMessage, data);
            }
        }

        /// <summary>
        /// Converts to json data.
        /// </summary>
        /// <param name="telegramMessage">The telegram message.</param>
        /// <returns>The Json Data.</returns>
        private StringContent ConvertToJsonData(TelegramMessage telegramMessage)
        {
            var messageJson = JsonConvert.SerializeObject(telegramMessage);

            var data = new StringContent(messageJson, Encoding.UTF8, "application/json");

            return data;
        }
    }
}
