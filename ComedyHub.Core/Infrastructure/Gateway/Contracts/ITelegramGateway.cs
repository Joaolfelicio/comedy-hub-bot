// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="ITelegramGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Model.Notification.TelegramMessage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    /// <summary>
    /// Interface ITelegramGateway
    /// </summary>
    public interface ITelegramGateway
    {
        /// <summary>
        /// Sends the photo message.
        /// </summary>
        /// <param name="telegramPhotoMessage">The telegram photo message.</param>
        /// <returns></returns>
        Task SendPhotoMessage(TelegramPhotoMessage telegramPhotoMessage);

        /// <summary>
        /// Sends the text message.
        /// </summary>
        /// <param name="telegramTextMessage">The telegram text message.</param>
        /// <returns></returns>
        Task SendTextMessage(TelegramTextMessage telegramTextMessage);
    }
}
