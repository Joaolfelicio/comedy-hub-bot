// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-16-2020
// ***********************************************************************
// <copyright file="MemeOrchestrator.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Manages the whole proccess</summary>
// ***********************************************************************
using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Components.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    /// <summary>
    /// Class MemeOrchestrator.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.IMemeOrchestrator" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.IMemeOrchestrator" />
    public class MemeOrchestrator : IMemeOrchestrator
    {
        /// <summary>
        /// The meme processor
        /// </summary>
        private readonly IMemeProcessor _memeProcessor;
        /// <summary>
        /// The publish component
        /// </summary>
        private readonly IPublishComponent _publishComponent;
        /// <summary>
        /// The notification component
        /// </summary>
        private readonly INotificationComponent _notificationComponent;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<MemeOrchestrator> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemeOrchestrator"/> class.
        /// </summary>
        /// <param name="memeProcessor">The meme processor.</param>
        /// <param name="publishComponent">The publish component.</param>
        /// <param name="notificationComponent">The notification component.</param>
        /// <param name="logger">The logger.</param>
        public MemeOrchestrator(IMemeProcessor memeProcessor,
                                IPublishComponent publishComponent,
                                INotificationComponent notificationComponent,
                                ILogger<MemeOrchestrator> logger)
        {
            _memeProcessor = memeProcessor;
            _publishComponent = publishComponent;
            _notificationComponent = notificationComponent;
            _logger = logger;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public async Task Process()
        {
            try
            {
                var meme = await _memeProcessor.ProcessMeme();

                var publishedObj = _publishComponent.PublishMeme(meme);

                _logger.LogInformation("Sucessfully published meme");

                await _notificationComponent.SendSucessfulNotification(publishedObj);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to process meme");

                await _notificationComponent.SendFailureNotification(exception);

                throw;
            }
        }
    }
}
