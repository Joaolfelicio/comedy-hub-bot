// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-04-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="NotificationComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Handles the notification process</summary>
// ***********************************************************************
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    /// <summary>
    /// Class NotificationComponent.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.INotificationComponent" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.INotificationComponent" />
    public class NotificationComponent : INotificationComponent
    {
        /// <summary>
        /// The notification telegram service
        /// </summary>
        private readonly INotificationTelegramService _notificationTelegramService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationComponent"/> class.
        /// </summary>
        /// <param name="notificationTelegramService">The notification telegram service.</param>
        public NotificationComponent(INotificationTelegramService notificationTelegramService)
        {
            _notificationTelegramService = notificationTelegramService;
        }

        /// <summary>
        /// Sends the sucessful notification.
        /// </summary>
        /// <param name="publishedModel">The published model.</param>
        public async Task SendSucessfulNotification(PublishedModel publishedModel)
        {
            await _notificationTelegramService.SendTelegramSuccessNotification(publishedModel);
        }

        /// <summary>
        /// Sends the failure notification.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public async Task SendFailureNotification(Exception exception)
        {
            await _notificationTelegramService.SendTelegramFailureNotification(exception);
        }
    }
}
