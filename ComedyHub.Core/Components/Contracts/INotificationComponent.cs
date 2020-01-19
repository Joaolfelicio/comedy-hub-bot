// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-04-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="INotificationComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components.Contracts
{
    /// <summary>
    /// Interface INotificationComponent
    /// </summary>
    public interface INotificationComponent
    {
        /// <summary>
        /// Sends the sucessful notification.
        /// </summary>
        /// <param name="publishedModel">The published model.</param>
        /// <returns></returns>
        Task SendSucessfulNotification(PublishedModel publishedModel);
        /// <summary>
        /// Sends the failure notification.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        Task SendFailureNotification(Exception exception);
    }
}
