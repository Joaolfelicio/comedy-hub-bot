// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-04-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="INotificationTelegramService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Handles the notifications throught telegram</summary>
// ***********************************************************************
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface INotificationTelegramService
    /// </summary>
    public interface INotificationTelegramService
    {
        /// <summary>
        /// Sends the telegram sucess notification.
        /// </summary>
        /// <param name="memePublished">The meme published.</param>
        /// <returns></returns>
        Task SendTelegramSucessNotification(PublishedModel memePublished);
        /// <summary>
        /// Sends the telegram failure notification.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        Task SendTelegramFailureNotification(Exception exception);
    }
}
